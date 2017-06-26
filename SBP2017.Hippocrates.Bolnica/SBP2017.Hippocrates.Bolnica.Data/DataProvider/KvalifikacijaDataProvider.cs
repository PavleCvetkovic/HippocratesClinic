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
    public class KvalifikacijaDataProvider
    {
        public static IList<KvalifikacijaDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<Kvalifikacija> iskustva = s.QueryOver<Kvalifikacija>().List();
            List<KvalifikacijaDto> listDTO = new List<KvalifikacijaDto>();
            foreach (Kvalifikacija i in iskustva)
            {
                KvalifikacijaDto dto = new KvalifikacijaDto()
                {
                    Id = i.Id,
                    Vrsta = i.Vrsta,
                    Institucija = i.Institucija,
                    IdZaposleni = i.Zaposleni.Id
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static KvalifikacijaDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Kvalifikacija d = s.Get<Kvalifikacija>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new KvalifikacijaDto();
            }
            KvalifikacijaDto kdto = new KvalifikacijaDto()
            {
                Id = d.Id,
                Vrsta = d.Vrsta,
                Institucija = d.Institucija,
                IdZaposleni = d.Zaposleni.Id
            };
            s.Close();
            return kdto;
        }

        public static bool Add(KvalifikacijaDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Kvalifikacija d = new Kvalifikacija();

            d.Institucija = dto.Institucija;
            d.Vrsta = dto.Vrsta;
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

        public static bool Update(int id, KvalifikacijaDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Kvalifikacija obj = s.Get<Kvalifikacija>(id);
            if (obj == null)
                obj = new Kvalifikacija();

            obj.Institucija = dto.Institucija;
            obj.Vrsta = dto.Vrsta;
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

            Kvalifikacija d = s.Get<Kvalifikacija>(id);
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
