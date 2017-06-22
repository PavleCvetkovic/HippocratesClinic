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
    public class SmenaController : ApiController
    {
        // GET: api/Dobavljac
        public IHttpActionResult GetAll()
        {
            IList<SmenaDto> dtolist = SmenaDataProvider.GetAll();
            if (dtolist.Count == 0)
                return Content(HttpStatusCode.NotFound, "Nema rezultata");
            return Content(HttpStatusCode.OK, dtolist);
        }

        // GET: api/Dobavljac/5
        public IHttpActionResult Get(int id)
        {
            bool found = true;
            SmenaDto d = SmenaDataProvider.Get(id, out found);
            if (!found)
                return Content(HttpStatusCode.NotFound, "Nema rezultata za trazeni ID: " + id);
            return Content(HttpStatusCode.OK, d);
        }

        // POST: api/Dobavljac
        public IHttpActionResult Post([FromBody]SmenaDto value)
        {
            string s = "";
            if (SmenaDataProvider.AddSmena(value, out s))
                return Content(HttpStatusCode.Created, s);
            return Content(HttpStatusCode.BadRequest, s);

        }

        // PUT: api/Dobavljac/5
        public IHttpActionResult Put(int id, [FromBody]SmenaDto value)
        {
            string st = "";
            if (SmenaDataProvider.UpdateSmena(id, value, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }

        // DELETE: api/Dobavljac/5
        public IHttpActionResult Delete(int id)
        {
            string st = "";
            if (SmenaDataProvider.DeleteSmena(id, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);

        }
    }
}
