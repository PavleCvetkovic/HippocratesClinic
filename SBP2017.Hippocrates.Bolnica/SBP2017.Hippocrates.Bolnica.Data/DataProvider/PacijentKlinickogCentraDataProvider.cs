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
    public class PacijentKlinickogCentraDataProvider
    {
        public static IList<PacijentKlinickogCentraDto> GetAll()
        {
            ISession s = DataLayer.GetSession();
            IList<PacijentKlinickogCentra> dlist = s.QueryOver<PacijentKlinickogCentra>().List<PacijentKlinickogCentra>();
            List<PacijentKlinickogCentraDto> dtolist = new List<PacijentKlinickogCentraDto>();
            
            foreach (PacijentKlinickogCentra d in dlist)
            {
               
                    PacijentKlinickogCentraDto dto = new PacijentKlinickogCentraDto();

                    dto.Id = d.Id;
                    dto.Ime = d.Ime;
                    dto.Prezime = d.Prezime;
                    dto.Adresa = d.Adresa;
                    dto.BracniStatus = d.BracniStatus;
                    dto.JMBG = d.JMBG;
                    dto.Pol = d.Pol;
                    dto.DatumRodjenja = d.DatumRodjenja.ToString();
                    dtolist.Add(dto);
                
            }
            s.Close();
            return dtolist;
        }

        public static PacijentKlinickogCentraDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            PacijentKlinickogCentra d = s.Get<PacijentKlinickogCentra>(id);
            if (d == null)
            {
                s.Close();
                found = false;
                return new PacijentKlinickogCentraDto();
            }
            PacijentKlinickogCentraDto dto = new PacijentKlinickogCentraDto()
            {
                Id = d.Id,
                Ime = d.Ime,
                Prezime = d.Prezime,
                Adresa = d.Adresa,
                BracniStatus = d.BracniStatus,
                JMBG = d.JMBG,
                Pol = d.Pol,
                DatumRodjenja = d.DatumRodjenja.ToString()
            };

            s.Close();
            return dto;
        }

        public static bool AddPacijentKlinickogCentra(PacijentKlinickogCentraDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            PacijentKlinickogCentra d = new PacijentKlinickogCentra();

            d.Ime = dto.Ime;
            d.Prezime = dto.Prezime;
            d.Adresa = dto.Adresa;
            d.BracniStatus = dto.BracniStatus;
            d.DatumRodjenja = DateTime.Parse(dto.DatumRodjenja);
            d.JMBG = dto.JMBG;
            d.Pol = dto.Pol;
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

        public static bool UpdatePacijentKlinickogCentra(int id, PacijentKlinickogCentraDto dto, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            PacijentKlinickogCentra d = s.Get<PacijentKlinickogCentra>(id);
            if (d == null)
                d = new PacijentKlinickogCentra();


            d.Ime = dto.Ime;
            d.Prezime = dto.Prezime;
            d.Adresa = dto.Adresa;
            d.BracniStatus = dto.BracniStatus;
            d.DatumRodjenja = DateTime.Parse(dto.DatumRodjenja);
            d.JMBG = dto.JMBG;
            d.Pol = dto.Pol;
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
        //nije u funkciji jos uvek
        public static bool DeletePacijentKlinickogCentra(int id, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno obrisan objekat";

            PacijentKlinickogCentra d = s.Get<PacijentKlinickogCentra>(id);
            if (d == null)
            {
                success = "Ne postoji objekata sa ID: " + id;
                return false;
            }
            try
            {
                foreach (BoraviNaKlinici b in d.Klinike)
                {
                    s.Delete(b);
                }
                foreach (Pregled p in d.Pregledi)
                {
                    s.Delete(p);
                }
                foreach (PacijentiCekaju c in d.ListeCekanja)
                {

                    s.Delete(c);
                }
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
