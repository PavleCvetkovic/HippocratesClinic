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
    public class DobavljacController : ApiController
    {
        // GET: api/Dobavljac
        public IHttpActionResult GetAll()
        {
            IList<DobavljacDto> dtolist = DobavljacDataProvider.GetAll();
            if (dtolist.Count == 0)
                return Content(HttpStatusCode.NoContent, "Nema rezultata");
            return Content(HttpStatusCode.OK, dtolist);
        }

        // GET: api/Dobavljac/5
        public IHttpActionResult Get(int id)
        {
            //DobavljacDto d = null;
            return Content(HttpStatusCode.NotImplemented, "Ne radi");
            bool found = true;
            DobavljacDto d = DobavljacDataProvider.Get(id, out found);
            if (!found)
                return Content(HttpStatusCode.NoContent, "Nema rezultata za trazeni ID: " + id);
            return Content(HttpStatusCode.OK, d);
        }

        // POST: api/Dobavljac
        public IHttpActionResult Post([FromBody]DobavljacDto value)
        {
            string s = "";
            if (DobavljacDataProvider.AddDobavljac(value, out s))
                return Content(HttpStatusCode.Created, s);
            return Content(HttpStatusCode.BadRequest, s);

        }

        // PUT: api/Dobavljac/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dobavljac/5
        public void Delete(int id)
        {
        }
    }
}
