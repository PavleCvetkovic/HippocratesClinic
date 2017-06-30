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
                return Content(HttpStatusCode.NotFound, "Nema rezultata");
            return Content(HttpStatusCode.OK, dtolist);
        }

        // GET: api/Dobavljac/5
        public IHttpActionResult Get(int id)
        {
            //DobavljacDto d = null;
            //return Content(HttpStatusCode.NotImplemented, "Ne radi");
            //ISession s = DataLayer.GetSession();
            ////Dobavljac dob = s.Get<Dobavljac>(id);
            //var dob = s.Get(typeof(Dobavljac), id);
            //if (dob == null)
            //    return Content(HttpStatusCode.NotFound, "Nije nasao nista");
            //Dobavljac dobavljac = (Dobavljac)dob;
            //string p = dobavljac.Id + " " + dobavljac.Ime;
            //s.Close();
            //return Content(HttpStatusCode.OK, p);

            bool found = true;
            DobavljacDto d = DobavljacDataProvider.Get(id, out found);
            if (!found)
                return Content(HttpStatusCode.NotFound, "Nema rezultata za trazeni ID: " + id);
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
        public IHttpActionResult Put(int id, [FromBody]DobavljacDto value)
        {
            string st = "";
            if (DobavljacDataProvider.UpdateDobavljac(id, value, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }

        // DELETE: api/Dobavljac/5
        public IHttpActionResult Delete(int id)
        {
            string st = "";
            if (DobavljacDataProvider.DeleteDobavljac(id, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }
    }
}
