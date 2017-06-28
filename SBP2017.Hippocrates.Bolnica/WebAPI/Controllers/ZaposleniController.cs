using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using SBP2017.Hippocrates.Bolnica.Data;
using NHibernate;

namespace WebAPI.Controllers
{
    public class ZaposleniController : ApiController
    {
        // GET: api/Zaposleni
        public IEnumerable<ZaposleniDto> GetZaposlene()
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Zaposleni");
            IList<Zaposleni> zaposleni = q.List<Zaposleni>();
            List<ZaposleniDto> zaposleniDto = new List<ZaposleniDto>();
            foreach(Zaposleni zap in zaposleni)
            {
                ZaposleniDto zdto = new ZaposleniDto()
                {
                    Id = zap.Id,
                    Ime = zap.Ime,
                    Prezime = zap.Prezime,
                    Password = zap.Password,
                    Pol = zap.Pol,
                    JMBG = zap.JMBG,
                    DatumRodjenja = zap.DatumRodjenja.ToString(),
                    Telefon = zap.Telefon,
                    TipZaposlenog = zap.TipZaposlenog,
                    Adresa = zap.Adresa
                };
                zaposleniDto.Add(zdto);
            }
            IEnumerable<ZaposleniDto> zaposlenidto = zaposleniDto;
            s.Close();
            return zaposlenidto;
        }

        // GET: api/Zaposleni/5
        public ZaposleniDto GetZaposlenog(int id)
        {
            ISession s = DataLayer.GetSession();
            Zaposleni zap = s.Load<Zaposleni>(id);
            ZaposleniDto z = new ZaposleniDto()
            {
                Id = zap.Id,
                Ime = zap.Ime,
                Prezime = zap.Prezime,
                Password = zap.Password,
                Pol = zap.Pol,
                JMBG = zap.JMBG,
                DatumRodjenja = zap.DatumRodjenja.ToString(),
                Telefon = zap.Telefon,
                TipZaposlenog = zap.TipZaposlenog,
                Adresa = zap.Adresa
            };
            s.Close();
            return z;
        }

        // POST: api/Zaposleni
        public IHttpActionResult Post([FromBody]ZaposleniDto value)
        {

            
            try
            {
                ISession s = DataLayer.GetSession();
                Klinika klinika = s.Load<Klinika>(value.IdKlinike);
                KlinickiCentar kc = klinika.KlinickiCentar;
                Ugovor u = new Ugovor()
                {
                    Pozicija = value.TipZaposlenog,
                    TipIsplate = value.TipIsplate,
                    TipUgovora = value.TipUgovora,
                    Plata = value.Plata,
                    BrojSatiNedeljno = value.BrojSatiNedeljno,
                    KlinickiCentar = kc,
                    Id = value.IdUgovora

                };
                if (value.TipZaposlenog == "SPECIJALISTA")
                {
                    Specijalista zaposljeni = new Specijalista();
                    Klinika k = s.Load<Klinika>(value.IdKlinike);
                    zaposljeni.Klinika = k;
                    zaposljeni.Ime = value.Ime;
                    zaposljeni.Prezime = value.Prezime;
                    zaposljeni.Telefon = value.Telefon;
                    zaposljeni.Pol = value.Pol;
                    zaposljeni.Password = value.Password;
                    zaposljeni.Adresa = value.Adresa;
                    zaposljeni.DatumRodjenja = DateTime.Parse(value.DatumRodjenja);
                    zaposljeni.TipZaposlenog = value.TipZaposlenog;
                    zaposljeni.JMBG = value.JMBG;
                    u.Zaposleni = zaposljeni;
                    zaposljeni.Ugovor = u;
                    s.Save(u);
                    s.Save(zaposljeni);


                }
                else if (value.TipZaposlenog == "SESTRA")
                {
                    Sestra zaposljeni = new Sestra();
                    Klinika k = s.Load<Klinika>(value.IdKlinike);
                    zaposljeni.Klinika = k;
                    zaposljeni.Ime = value.Ime;
                    zaposljeni.Prezime = value.Prezime;
                    zaposljeni.Telefon = value.Telefon;
                    zaposljeni.Pol = value.Pol;
                    zaposljeni.Password = value.Password;
                    zaposljeni.Adresa = value.Adresa;
                    zaposljeni.DatumRodjenja = DateTime.Parse(value.DatumRodjenja);
                    zaposljeni.TipZaposlenog = value.TipZaposlenog;
                    zaposljeni.JMBG = value.JMBG;
                    zaposljeni.TipSestre = "MLADJA";
                    zaposljeni.Ugovor = u;
                    u.Zaposleni = zaposljeni;
                    s.Save(u);
                    s.Save(zaposljeni);
                }
                else if (value.TipZaposlenog == "BOLNICAR")
                {
                    Bolnicar zaposljeni = new Bolnicar();
                    Klinika k = s.Load<Klinika>(value.IdKlinike);
                    zaposljeni.Klinika = k;
                    zaposljeni.Ime = value.Ime;
                    zaposljeni.Prezime = value.Prezime;
                    zaposljeni.Telefon = value.Telefon;
                    zaposljeni.Pol = value.Pol;
                    zaposljeni.Password = value.Password;
                    zaposljeni.Adresa = value.Adresa;
                    zaposljeni.DatumRodjenja = DateTime.Parse(value.DatumRodjenja);
                    zaposljeni.TipZaposlenog = value.TipZaposlenog;
                    zaposljeni.JMBG = value.JMBG;
                    zaposljeni.Ugovor = u;
                    u.Zaposleni = zaposljeni;
                    s.Save(u);
                    s.Save(zaposljeni);
                }
                else if (value.TipZaposlenog == "POMOCNO OSOBLJE")
                {
                    PomocnoOsoblje zaposljeni = new PomocnoOsoblje();
                    Klinika k = s.Load<Klinika>(value.IdKlinike);
                    zaposljeni.Klinika = k;
                    zaposljeni.Ime = value.Ime;
                    zaposljeni.Prezime = value.Prezime;
                    zaposljeni.Telefon = value.Telefon;
                    zaposljeni.Pol = value.Pol;
                    zaposljeni.Password = value.Password;
                    zaposljeni.Adresa = value.Adresa;
                    zaposljeni.DatumRodjenja = DateTime.Parse(value.DatumRodjenja);
                    zaposljeni.TipZaposlenog = value.TipZaposlenog;
                    zaposljeni.JMBG = value.JMBG;
                    zaposljeni.Ugovor = u;
                    u.Zaposleni = zaposljeni;
                    s.Save(u);
                    s.Save(zaposljeni);
                }
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Greska prilikom upisivanja u bazu podataka " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Objekat je upisan u bazu");
        }

        // PUT: api/Zaposleni/5
        public IHttpActionResult Put(int id, [FromBody]ZaposleniDto value)
        {
            try {
                ISession s = DataLayer.GetSession();

                Zaposleni z = s.Load<Zaposleni>(value.Id);
                z.Ime = value.Ime;
                z.Prezime = value.Prezime;
                z.Password = value.Password;
                z.Adresa = value.Adresa;
                z.DatumRodjenja = DateTime.Parse(value.DatumRodjenja);
                z.JMBG = value.JMBG;
                z.Pol = value.Pol;
                z.TipZaposlenog = value.TipZaposlenog;
                z.Klinika = s.Load<Klinika>(value.IdKlinike);
                z.Telefon = value.Telefon;
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Greska prilikom upisivanja u bazu podataka " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Objekat je azuriran/upisan u bazu");
        }

        // DELETE: api/Zaposleni/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zaposleni z = s.Load<Zaposleni>(id);
                Ugovor u = z.Ugovor;
                s.Delete(u);
                s.Delete(z);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Greska prilikom brisanja iz baze podataka " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Objekat je Obrisan iz baze");
        }
    }
}
