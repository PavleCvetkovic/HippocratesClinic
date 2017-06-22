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
    public class RodjakController : ApiController
    {
        // GET: api/Rodjak
        public IHttpActionResult Get()
        {
            IList<RodjakDto> dtolist = RodjakDataProvider.GetAll();
            if (dtolist.Count == 0)
                return Content(HttpStatusCode.NotFound, "Nema rezultata");
            return Content(HttpStatusCode.OK, dtolist);
        }

        // GET: api/Rodjak/5
        public IHttpActionResult Get(int id)
        {
            bool found = true;
            RodjakDto d = RodjakDataProvider.Get(id, out found);
            if (!found)
                return Content(HttpStatusCode.NotFound, "Nema rezultata za trazeni ID: " + id);
            return Content(HttpStatusCode.OK, d);
        }

        // POST: api/Rodjak
        public IHttpActionResult Post([FromBody]RodjakDto value)
        {
            string s = "";
            if (RodjakDataProvider.AddRodjak(value, out s))
                return Content(HttpStatusCode.Created, s);
            return Content(HttpStatusCode.BadRequest, s);
        }

        // PUT: api/Rodjak/5
        public IHttpActionResult Put(int id, [FromBody]RodjakDto value)
        {
            string st = "";
            if (RodjakDataProvider.UpdateRodjak(id, value, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }

        // DELETE: api/Rodjak/5
        public IHttpActionResult Delete(int id)
        {
            string st = "";
            if (RodjakDataProvider.DeleteRodjak(id, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }
    }
}
