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
    public class PregledDataProvider
    {
        public static IList<PregledDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<Pregled> iskustva = s.QueryOver<Pregled>().List();
            List<PregledDto> listDTO = new List<PregledDto>();
            foreach (Pregled i in iskustva)
            {
                PregledDto dto = new PregledDto()
                {
                    Id = i.Id,
                    Datum = i.Datum,
                    Vreme = i.Vreme,
                    Prostorija = i.Prostorija,
                    IdPacijent = i.Pacijent == null ? -1 : i.Pacijent.Id,
                    IdSpecijalista = i.Specijalista == null ? -1 : i.Specijalista.Id,
                    IdIzabranogLekara = "nema izabranog lekara"
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static PregledDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Pregled i = s.Get<Pregled>(id);
            if (i == null)
            {
                s.Close();
                found = false;
                return new PregledDto();
            }
            PregledDto kdto = new PregledDto()
            {
                Id = i.Id,
                Datum = i.Datum,
                Vreme = i.Vreme,
                Prostorija = i.Prostorija,
                IdPacijent = i.Pacijent == null ? -1 : i.Pacijent.Id,
                IdSpecijalista = i.Specijalista == null ? -1 : i.Specijalista.Id,
                IdIzabranogLekara = "nema izabranog lekara"
            };
            s.Close();
            return kdto;
        }

        public static bool Add(PregledDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Pregled d = new Pregled();


            //d.Id = i.Id,
            d.Datum = i.Datum;
            d.Vreme = i.Vreme;
            d.Prostorija = i.Prostorija;
            d.Pacijent = s.Get<PacijentKlinickogCentra>(i.IdPacijent);
            d.Specijalista = s.Get<Zaposleni>(i.IdSpecijalista);
            d.IdIzabranogLekara = "nema izabranog lekara";
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

        public static bool Update(int id, PregledDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Pregled obj = s.Get<Pregled>(id);
            if (obj == null)
                obj = new Pregled();

            obj.Datum = i.Datum;
            obj.Vreme = i.Vreme;
            obj.Prostorija = i.Prostorija;
            obj.Pacijent = s.Get<PacijentKlinickogCentra>(i.IdPacijent);
            obj.Specijalista = s.Get<Zaposleni>(i.IdSpecijalista);
            obj.IdIzabranogLekara = "nema izabranog lekara";

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

            Pregled d = s.Get<Pregled>(id);
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
