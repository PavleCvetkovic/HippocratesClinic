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
    public class UgovorDataProvider
    {
        public static IList<UgovorDto> GetAll()
        {
            ISession s = DataLayer.GetSession();
            IList<Ugovor> rlist = s.QueryOver<Ugovor>().List<Ugovor>();
            List<UgovorDto> rtolist = new List<UgovorDto>();
            foreach (Ugovor r in rlist)
            {
                UgovorDto udto = new UgovorDto()
                {
                    Id = r.Id,
                    BrojSatiNedeljno = r.BrojSatiNedeljno,
                    IdKlinickogCentra = r.KlinickiCentar.Id,
                    Plata = r.Plata,
                    Pozicija = r.Pozicija,
                    IdZaposlenog = r.Zaposleni.Id,
                    TipIsplate = r.TipIsplate,
                    TipUgovora = r.TipUgovora
                };
                rtolist.Add(udto);
            }
            s.Close();
            return rtolist;
        }

        public static UgovorDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Ugovor r = s.Get<Ugovor>(id);
            if (r == null)
            {
                s.Close();
                found = false;
                return new UgovorDto();
            }

            UgovorDto udto = new UgovorDto()
            {
                Id = r.Id,
                BrojSatiNedeljno = r.BrojSatiNedeljno,
                IdKlinickogCentra = r.KlinickiCentar.Id,
                Plata = r.Plata,
                Pozicija = r.Pozicija,
                IdZaposlenog = r.Zaposleni.Id,
                TipIsplate = r.TipIsplate,
                TipUgovora = r.TipUgovora
            };

            s.Close();
            return udto;
        }

        public static bool AddUgovor(UgovorDto r, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Ugovor d = new Ugovor()
            {
                Id = r.Id,
                BrojSatiNedeljno = r.BrojSatiNedeljno,
                Plata = r.Plata,
                Pozicija = r.Pozicija,
                TipIsplate = r.TipIsplate,
                TipUgovora = r.TipUgovora
            };
            d.KlinickiCentar = s.Load<KlinickiCentar>(r.IdKlinickogCentra);
            d.Zaposleni = s.Load<Zaposleni>(r.IdZaposlenog);
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

        public static bool UpdateUgovor(int id, UgovorDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Ugovor d = s.Load<Ugovor>(id);
            if (d == null)
                d = new Ugovor();

            d.Plata = dto.Plata;
            d.Pozicija = dto.Pozicija;
            d.TipIsplate = dto.TipIsplate;
            d.TipUgovora = dto.TipUgovora;
            d.KlinickiCentar = s.Load<KlinickiCentar>(dto.IdKlinickogCentra);
            d.Zaposleni = s.Load<Zaposleni>(dto.IdZaposlenog);
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

        public static bool DeleteUgovor(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";
            Ugovor d = s.Load<Ugovor>(id);
            d.KlinickiCentar.Ugovori.Remove(d);
            d.Zaposleni.Ugovor = null;
            d.Zaposleni = null;
            d.KlinickiCentar = null;
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
