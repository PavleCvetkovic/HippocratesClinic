using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using SBP2017.Hippocrates.Bolnica.Data.DataProvider;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PacijentKlinickogCentraController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            IList<PacijentKlinickogCentraDto> dtolist = PacijentKlinickogCentraDataProvider.GetAll();
            if (dtolist.Count == 0)
                return Content(HttpStatusCode.NotFound, "Nema rezultata");
            return Content(HttpStatusCode.OK, dtolist);
        }

        // GET: api/Dobavljac/5
        public IHttpActionResult Get(int id)
        {

            bool found = true;
            PacijentKlinickogCentraDto d = PacijentKlinickogCentraDataProvider.Get(id, out found);
            if (!found)
                return Content(HttpStatusCode.NotFound, "Nema rezultata za trazeni ID: " + id);
            return Content(HttpStatusCode.OK, d);
        }

        // POST: api/Dobavljac
        public IHttpActionResult Post([FromBody]PacijentKlinickogCentraDto value)
        {
            string s = "";
            if (PacijentKlinickogCentraDataProvider.AddPacijentKlinickogCentra(value, out s))
                return Content(HttpStatusCode.Created, s);
            return Content(HttpStatusCode.BadRequest, s);

        }

        // PUT: api/Dobavljac/5
        public IHttpActionResult Put(int id, [FromBody]PacijentKlinickogCentraDto value)
        {
            string st = "";
            if (PacijentKlinickogCentraDataProvider.UpdatePacijentKlinickogCentra(id, value, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }

        // DELETE: api/Dobavljac/5
        public IHttpActionResult Delete(int id)
        {
            string st = "";
            if (PacijentKlinickogCentraDataProvider.DeletePacijentKlinickogCentra(id, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }
    }
}
