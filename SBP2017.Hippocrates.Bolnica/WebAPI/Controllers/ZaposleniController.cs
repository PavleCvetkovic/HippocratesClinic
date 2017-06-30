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

using System.Data.OracleClient;

namespace WebAPI.Controllers
{
    public class ZaposleniController : ApiController
    {
        // GET: api/Zaposleni
        public IEnumerable<ZaposleniDto> GetAll()
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
                    IdKlinike = zap.Klinika == null ? -1 : zap.Klinika.Id,
                    IdUgovora = zap.Ugovor == null ? -1 : zap.Ugovor.Id,
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
        public IHttpActionResult Get(int id)
        {
            ISession s = DataLayer.GetSession();
            Zaposleni zap = s.Get<Zaposleni>(id);
            if (zap == null)
                return Content(HttpStatusCode.NotFound, "Ne postoji objekat sa ID: " + id);
            ZaposleniDto z = new ZaposleniDto()
            {
                Id = zap.Id,
                IdKlinike = zap.Klinika == null ? -1 : zap.Klinika.Id,
                IdUgovora = zap.Ugovor == null ? -1 : zap.Ugovor.Id,
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
            return Content(HttpStatusCode.OK, z);
        }

        // POST: api/Zaposleni
        public IHttpActionResult Post([FromBody]ZaposleniDto value)
        {
            
            try
            { 
                ISession s = DataLayer.GetSession();
                
                Zaposleni z = null;
                if (value.TipZaposlenog == "SPECIJALISTA")
                    z = new Specijalista();
                else if (value.TipZaposlenog == "SESTRA")
                    z = new Sestra();
                else if (value.TipZaposlenog == "BOLNICAR")
                    z = new Bolnicar();
                else if (value.TipZaposlenog == "POMOCNO OSOBLJE")
                    z = new PomocnoOsoblje();

                if (z == null)
                    return Content(HttpStatusCode.BadRequest, "Pogresan izbor tipa zaposlenog");

                s.CreateSQLQuery("INSERT INTO ZAPOSLENI(IME, PREZIME, ADRESA, TELEFON, POL, DATUM_RODJENJA, JMBG, ID_UGOVORA, ID_KLINIKE, PASSWORD, TIP_ZAPOSLENOG) VALUES ('"+value.Ime.ToString()+"','" + value.Prezime.ToString() + "','" + value.Adresa +"','"+value.Telefon.ToString() + "','" +value.Pol.ToString() + "','" + value.DatumRodjenja.ToString() + "','" + value.JMBG.ToString() + "',"+value.IdUgovora.ToString() + ","+value.IdKlinike+",'" + value.Password.ToString() + "','" + value.TipZaposlenog.ToString() + "')").ExecuteUpdate();
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
                z.DatumRodjenja = DateTime.Parse(value.DatumRodjenja); //DateTime.Parse(value.DatumRodjenja);
                z.JMBG = value.JMBG;
                z.Pol = value.Pol;
                z.TipZaposlenog = value.TipZaposlenog;
                z.Klinika = s.Get<Klinika>(value.IdKlinike);
                z.Ugovor = s.Get<Ugovor>(value.IdUgovora);
                z.Telefon = value.Telefon;

                s.Save(z);
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
                Zaposleni z = s.Get<Zaposleni>(id);
                if (z == null)
                    return Content(HttpStatusCode.BadRequest, "Ne postoji objekat sa trazenim ID: " + id);

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
