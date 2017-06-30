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
    public class NarudzbenicaDataProvider
    {
        public static IList<NarudzbenicaDto> GetAll()
        {
            //st = "";
            ISession s = DataLayer.GetSession();
            IList<Narudzbenica> iskustva = s.QueryOver<Narudzbenica>().List();
            List<NarudzbenicaDto> listDTO = new List<NarudzbenicaDto>();
            foreach (Narudzbenica i in iskustva)
            {
                NarudzbenicaDto dto = new NarudzbenicaDto()
                {
                    Id = i.Id,
                    Cena = i.Cena,
                    ImeKlinike = i.ImeKlinike,
                    ImeZaposlenog = i.ImeZaposlenog,
                    Kolicina = i.Kolicina,
                    Opis = i.Opis,
                    Naziv = i.Naziv,
                    IdKlinika = i.Klinika == null ? -1 : i.Klinika.Id,
                    IdNaruceniMaterijal = i.NaruceniMaterijal == null ? -1 : i.NaruceniMaterijal.Id,
                    DatumIsporuke = i.DatumIsporuke,
                    DatumNarudzbine = i.DatumNarudzbine
                };
                listDTO.Add(dto);
            }
            return listDTO;
        }

        public static NarudzbenicaDto Get(int id, out bool found)
        {
            found = true;
            ISession s = DataLayer.GetSession();
            Narudzbenica i = s.Get<Narudzbenica>(id);
            if (i == null)
            {
                s.Close();
                found = false;
                return new NarudzbenicaDto();
            }
            NarudzbenicaDto kdto = new NarudzbenicaDto()
            {
                Id = i.Id,
                Cena = i.Cena,
                ImeKlinike = i.ImeKlinike,
                ImeZaposlenog = i.ImeZaposlenog,
                Kolicina = i.Kolicina,
                Opis = i.Opis,
                Naziv = i.Naziv,
                IdKlinika = i.Klinika == null ? -1 : i.Klinika.Id,
                IdNaruceniMaterijal = i.NaruceniMaterijal == null ? -1 : i.NaruceniMaterijal.Id,
                DatumIsporuke = i.DatumIsporuke,
                DatumNarudzbine = i.DatumNarudzbine
            };
            s.Close();
            return kdto;
        }

        public static bool Add(NarudzbenicaDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan objekat";
            Narudzbenica d = new Narudzbenica();

            //d.Id = i.Id;
            d.Cena = i.Cena;
            d.ImeKlinike = i.ImeKlinike;
            d.ImeZaposlenog = i.ImeZaposlenog;
            d.Kolicina = i.Kolicina;
            d.Opis = i.Opis;
            d.Naziv = i.Naziv;
            d.Klinika = s.Get<Klinika>(i.IdKlinika);
            d.NaruceniMaterijal = s.Get<PotrosniMaterijal>(i.IdNaruceniMaterijal);
            d.DatumIsporuke = i.DatumIsporuke;
            d.DatumNarudzbine = i.DatumNarudzbine;
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

        public static bool Update(int id, NarudzbenicaDto i, out string success)
        {
            ISession s = DataLayer.GetSession();
            success = "Uspesno upisan/azuiran objekat";

            Narudzbenica obj = s.Get<Narudzbenica>(id);
            if (obj == null)
                obj = new Narudzbenica();

            obj.Cena = i.Cena;
            obj.ImeKlinike = i.ImeKlinike;
            obj.ImeZaposlenog = i.ImeZaposlenog;
            obj.Kolicina = i.Kolicina;
            obj.Opis = i.Opis;
            obj.Naziv = i.Naziv;
            obj.Klinika = s.Get<Klinika>(i.IdKlinika);
            obj.NaruceniMaterijal = s.Get<PotrosniMaterijal>(i.IdNaruceniMaterijal);
            obj.DatumIsporuke = i.DatumIsporuke;
            obj.DatumNarudzbine = i.DatumNarudzbine;
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

            Narudzbenica d = s.Get<Narudzbenica>(id);
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
