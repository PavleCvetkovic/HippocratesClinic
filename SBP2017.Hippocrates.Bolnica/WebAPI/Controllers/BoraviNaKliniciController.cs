using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //public virtual int Id { get; set; }
    //public virtual int OcekivaniBoravak { get; set; }
    //public virtual int BrojKreveta { get; set; }
    //public virtual int IdKlinika { get; set; }
    //public virtual int IdPacijentKlinickogCentra { get; set; }
    public class BoraviNaKliniciController : ApiController
    {
        // GET: api/BoraviNaKlinici
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from BoraviNaKlinici");
            IList<BoraviNaKlinici> lista = q.List<BoraviNaKlinici>();
            if (lista.Count == 0) // nema objekata
                return Content(HttpStatusCode.NoContent, "Nema trazenih rezultata");

            List<BoraviNaKliniciDto> listaDTO = new List<BoraviNaKliniciDto>();

            foreach (BoraviNaKlinici item in lista)
            {
                BoraviNaKliniciDto dto = new BoraviNaKliniciDto()
                {
                    Id = item.Id, 
                    IdKlinika = item.Klinika.Id,
                    IdPacijentKlinickogCentra = item.Pacijent.Id,
                    BrojKreveta = item.BrojKreveta,
                    OcekivaniBoravak = item.OcekivaniBoravak
                };
                listaDTO.Add(dto);
            }
            s.Close();
            IEnumerable<BoraviNaKliniciDto> numerable = listaDTO;
            return Ok(numerable);
        }

        // GET: api/BoraviNaKlinici/5
        public IHttpActionResult Get([FromUri] int id)
        {
            ISession s = DataLayer.GetSession();
            BoraviNaKlinici item = s.Get<BoraviNaKlinici>(id);
            if (item == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata sa ID: " + id);
            BoraviNaKliniciDto dto = new BoraviNaKliniciDto()
            {
                Id = item.Id,
                IdKlinika = item.Klinika.Id,
                IdPacijentKlinickogCentra = item.Pacijent.Id,
                BrojKreveta = item.BrojKreveta,
                OcekivaniBoravak = item.OcekivaniBoravak
            };
            s.Close();
            return Ok(dto);
        }

        // POST: api/BoraviNaKlinici
        public IHttpActionResult Post([FromBody]BoraviNaKliniciDto value)
        {
            ISession s = DataLayer.GetSession();
            Klinika k = s.Get<Klinika>(value.IdKlinika);
            PacijentKlinickogCentra pkc = s.Get<PacijentKlinickogCentra>(value.IdPacijentKlinickogCentra);
            if (k == null || pkc == null)
                return Content(HttpStatusCode.NotFound, "Ne postoji Klinika ili Pacijent sa unetim ID-om: " +
                    value.IdKlinika + " " + value.IdPacijentKlinickogCentra);

            BoraviNaKlinici bnk = new BoraviNaKlinici()
            {
                // bnk.Id = value.Id, // protected set (self-generated ID)
                Klinika = k,
                Pacijent = pkc,
                DatumPrijema = DateTime.Now.Date, // hard-coded (because it's NOT nullable in Database)
                OcekivaniBoravak = value.OcekivaniBoravak,
                BrojKreveta = value.BrojKreveta
            };
            try
            {
                s.Save(bnk);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                s.Close();
                return Content(HttpStatusCode.BadRequest, "Greska prilikom upisa u bazu " + ex.Message);
            }
            return Content(HttpStatusCode.Created, "Uspesno kreiran objekat");
        }

        // PUT: api/BoraviNaKlinici/5
        public IHttpActionResult Put(int id, [FromBody]BoraviNaKliniciDto value)
        {
            //return Content(HttpStatusCode.NotImplemented, "Nije implementirano, ne radi");
            ISession s = DataLayer.GetSession();
            BoraviNaKlinici item = s.Get<BoraviNaKlinici>(id);
            if (item == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata sa ID: " + id);

            Klinika k = s.Get<Klinika>(value.IdKlinika);
            PacijentKlinickogCentra pkc = s.Get<PacijentKlinickogCentra>(value.IdPacijentKlinickogCentra);
            if (k == null || pkc == null)
                return Content(HttpStatusCode.NotFound, "Ne postoji Klinika ili Pacijent sa unetim ID-om: " +
                    value.IdKlinika + " " + value.IdPacijentKlinickogCentra);

            item.Klinika = k;
            item.Pacijent= pkc;
            item.BrojKreveta = value.BrojKreveta;
            item.OcekivaniBoravak = value.OcekivaniBoravak;

            try
            {
                s.SaveOrUpdate(item);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                s.Close();
                return Content(HttpStatusCode.BadRequest, "Greska prilikom azuriranja/upisa objekta " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Uspesno azuriran/upisan objekat");
        }

        // DELETE: api/BoraviNaKlinici/5
        public IHttpActionResult Delete(int id)
        {
            ISession s = DataLayer.GetSession();
            BoraviNaKlinici item = s.Get<BoraviNaKlinici>(id);
            if (item == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata sa ID: " + id);
            try
            {
                s.Delete(item);
                s.Flush();
                s.Close();

            }
            catch (Exception ex)
            {
                s.Close();
                return Content(HttpStatusCode.BadRequest, "Greska prilikom brisanja objekta " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Uspesno obrisan objekat");

        }
    }
}
