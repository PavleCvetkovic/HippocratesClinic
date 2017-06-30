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
    public class KrevetDataProvider
    {
        public static IList<KrevetDto> GetAll()
        {
            ISession s = DataLayer.GetSession();
            IList<Krevet> dlist = s.QueryOver<Krevet>().List<Krevet>();
            List<KrevetDto> dtolist = new List<KrevetDto>();
            foreach (Krevet k in dlist)
            {
                KrevetDto kdto = new KrevetDto()
                {
                    Id = k.Id,
                    KlinickiCentar = k.KlinickiCentar.Ime,
                    Klinika = k.Klinika.Naziv
                };
                dtolist.Add(kdto);
            }
            s.Close();
            return dtolist;
        }

        public static KrevetDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Krevet d = s.Get<Krevet>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new KrevetDto();
            }
            KrevetDto kdto = new KrevetDto()
            {
                Id = d.Id,
                Klinika = d.Klinika.Naziv,
                KlinickiCentar = d.KlinickiCentar.Ime
            };
            s.Close();
            return kdto;
        }

        public static bool AddKrevet(KrevetDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Krevet d = new Krevet();

            d.KlinickiCentar = s.Load<KlinickiCentar>(dto.KlinickiCentar);
            d.Klinika = s.Load<Klinika>(dto.Klinika);
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

        public static bool UpdateKreveta(int id, KrevetDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Krevet krevet = s.Get<Krevet>(id);
            if (krevet == null)
                krevet = new Krevet();

            krevet.KlinickiCentar = s.Load<KlinickiCentar>(dto.KlinickiCentar);
            krevet.Klinika = s.Load<Klinika>(dto.Klinika);
            try
            {
                s.Save(krevet);
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

        public static bool DeleteKrevet(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";

            Krevet d = s.Get<Krevet>(id);
            if (d == null)
            {
                success = "Ne postoji objekata sa ID: " + id;
                return false;
            }
            try
            {
                d.Klinika.KoristiKrevete.Remove(d);
                d.KlinickiCentar.Kreveti.Remove(d);
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

