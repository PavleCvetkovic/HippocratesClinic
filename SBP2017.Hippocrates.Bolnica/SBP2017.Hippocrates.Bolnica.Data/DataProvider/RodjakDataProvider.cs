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
    public class RodjakDataProvider
    {
        public static IList<RodjakDto> GetAll()
        {
            ISession s = DataLayer.GetSession();
            IList<Rodjak> rlist = s.QueryOver<Rodjak>().List<Rodjak>();
            List<RodjakDto> rtolist = new List<RodjakDto>();
            foreach (Rodjak r in rlist)
            {
                RodjakDto rdto = new RodjakDto()
                {
                    Id = r.Id,
                    Ime = r.Ime,
                    Prezime = r.Prezime,
                    Telefon = r.Telefon,
                    Adresa = r.Adresa
                };
                rtolist.Add(rdto);
            }
            s.Close();
            return rtolist;
        }

        public static RodjakDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Rodjak r = s.Get<Rodjak>(id);
            if (r == null)
            {
                s.Close();
                found = false;
                return new RodjakDto();
            }

            RodjakDto dto = new RodjakDto()
            {
                Id = r.Id,
                Ime = r.Ime,
                Prezime = r.Prezime,
                Telefon = r.Telefon,
                Adresa = r.Adresa,
                Srodstvo = r.Srodstvo
            };
            s.Close();
            return dto;
        }

        public static bool AddRodjak(RodjakDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Rodjak d = new Rodjak();
            d.Ime = dto.Ime;
            d.Prezime = dto.Prezime;
            d.Adresa = dto.Adresa;
            d.Srodstvo = dto.Srodstvo;
            d.Telefon = dto.Telefon;
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

        public static bool UpdateRodjak(int id, RodjakDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Rodjak d = s.Get<Rodjak>(id);
            if (d == null)
                d = new Rodjak();
            
            d.Ime = dto.Ime;
            d.Prezime = dto.Prezime;
            d.Adresa = dto.Adresa;
            d.Telefon = dto.Telefon;
            d.Srodstvo = dto.Srodstvo;
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
        /* Gotova ce biti kad kontroler za Pacijenta ispisemo
        public static bool GetAllPacijenteUSrodstvu()
        {

        }
        */
        public static bool DeleteRodjak(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";

            Rodjak d = s.Get<Rodjak>(id);
            foreach(PacijentKlinickogCentra pc in d.PacijentiUSrodstvu)
            {
                pc.Rodjak = null;
            }
            d.PacijentiUSrodstvu = null;
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
                success = "Greska prilikom brisanja " + ex.Message;
                return false;
            }
        }
    }
}
