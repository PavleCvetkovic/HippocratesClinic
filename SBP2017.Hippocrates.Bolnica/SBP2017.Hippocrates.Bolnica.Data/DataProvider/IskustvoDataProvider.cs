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
    public class IskustvoDataProvider
    {
        public static IList<IskustvoDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<Iskustvo> iskustva = s.QueryOver<Iskustvo>().List();
            List<IskustvoDto> listDTO = new List<IskustvoDto>();
            foreach (Iskustvo i in iskustva)
            {
                IskustvoDto dto = new IskustvoDto()
                {
                    Id = i.Id,
                    Pozicija = i.Pozicija,
                    Institucija = i.Institucija,
                    IdZaposleni = i.Zaposleni.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static IskustvoDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Iskustvo d = s.Get<Iskustvo>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new IskustvoDto();
            }
            IskustvoDto kdto = new IskustvoDto()
            {
                Id = d.Id,
                Institucija = d.Institucija,
                Pozicija = d.Pozicija,
                IdZaposleni = d.Zaposleni.Id
            };
            s.Close();
            return kdto;
        }

        public static bool Add(IskustvoDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Iskustvo d = new Iskustvo();

            d.Institucija = dto.Institucija;
            d.Pozicija = dto.Pozicija;
            d.Id = dto.Id;
            d.Zaposleni = s.Get<Zaposleni>(dto.IdZaposleni);
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

        public static bool Update(int id, IskustvoDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Iskustvo obj = s.Get<Iskustvo>(id);
            if (obj == null)
                obj = new Iskustvo();

            obj.Institucija = dto.Institucija;
            obj.Pozicija = dto.Pozicija;
            obj.Id = dto.Id;
            obj.Zaposleni = s.Get<Zaposleni>(dto.IdZaposleni);
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

            Iskustvo d = s.Get<Iskustvo>(id);
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
