using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.DataProvider
{
    public class KlinickiCentarProvider
    {
        public static IList<KlinickiCentarDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<KlinickiCentar> iskustva = s.QueryOver<KlinickiCentar>().List();
            List<KlinickiCentarDto> listDTO = new List<KlinickiCentarDto>();
            foreach (KlinickiCentar i in iskustva)
            {
                KlinickiCentarDto dto = new KlinickiCentarDto()
                {
                    Id = i.Id,
                    Ime = i.Ime,
                    Lokacija = i.Lokacija,
                    IdCentralniMagacin = i.CentralniMagacin == null ? -1 : i.CentralniMagacin.Id,
                    IdDirektorKlinickogCentra = i.DirektorKlinickogCentra == null ? -1 : i.DirektorKlinickogCentra.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static KlinickiCentarDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            KlinickiCentar d = s.Get<KlinickiCentar>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new KlinickiCentarDto();
            }
            KlinickiCentarDto kdto = new KlinickiCentarDto()
            {
                Id = d.Id,
                Ime = d.Ime,
                Lokacija = d.Lokacija,
                IdCentralniMagacin = d.CentralniMagacin == null ? -1 : d.CentralniMagacin.Id,
                IdDirektorKlinickogCentra = d.DirektorKlinickogCentra == null ? -1 : d.DirektorKlinickogCentra.Id
            };
            s.Close();
            return kdto;
        }

        public static bool Add(KlinickiCentarDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            KlinickiCentar d = new KlinickiCentar();

            //d.Id = dto.Id;
            d.Ime = dto.Ime;
            d.Lokacija = dto.Lokacija;
            d.DirektorKlinickogCentra = s.Get<Zaposleni>(dto.IdDirektorKlinickogCentra);
            d.CentralniMagacin = s.Get<CentralniMagacin>(dto.IdCentralniMagacin);
            try
            {
                s.Save(d);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                success = "Greska prilikom upisa u bazu " + ex.Message;
                return false;
            }
        }

        public static bool Update(int id, KlinickiCentarDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            KlinickiCentar obj = s.Get<KlinickiCentar>(id);
            if (obj == null)
                obj = new KlinickiCentar();

            obj.Ime = dto.Ime;
            obj.Lokacija = dto.Lokacija;
            obj.DirektorKlinickogCentra = s.Get<Zaposleni>(dto.IdDirektorKlinickogCentra);
            obj.CentralniMagacin = s.Get<CentralniMagacin>(dto.IdCentralniMagacin);
            try
            {
                s.Save(obj);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                success = "Greska prilikom upisa u bazu " + ex.Message;
                return false;
            }
        }

        public static bool Delete(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";

            KlinickiCentar d = s.Get<KlinickiCentar>(id);
            if (d == null)
            {
                success = "Ne postoji objekata sa ID: " + id;
                return false;
            }
            try
            {
                s.Delete(d);
                s.Flush();
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                success = "Greska prilikom upisa u bazu " + ex.Message;
                return false;
            }
        }

    }
}
