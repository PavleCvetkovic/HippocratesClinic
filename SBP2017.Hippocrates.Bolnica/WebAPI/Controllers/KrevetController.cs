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
    public class KrevetController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            IList<KrevetDto> dtolist = KrevetDataProvider.GetAll();
            if (dtolist.Count == 0)
                return Content(HttpStatusCode.NotFound, "Nema rezultata");
            return Content(HttpStatusCode.OK, dtolist);
        }


        public IHttpActionResult Get(int id)
        {

            bool found = true;
            KrevetDto d = KrevetDataProvider.Get(id, out found);
            if (!found)
                return Content(HttpStatusCode.NotFound, "Nema rezultata za trazeni ID: " + id);
            return Content(HttpStatusCode.OK, d);
        }


        public IHttpActionResult Post([FromBody]KrevetDto value)
        {
            string s = "";
            if (KrevetDataProvider.AddKrevet(value, out s))
                return Content(HttpStatusCode.Created, s);
            return Content(HttpStatusCode.BadRequest, s);

        }

        public IHttpActionResult Put(int id, [FromBody]DobavljacDto value)
        {
            string st = "";
            if (DobavljacDataProvider.UpdateDobavljac(id, value, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }


        public IHttpActionResult Delete(int id)
        {
            string st = "";
            if (KrevetDataProvider.DeleteKrevet(id, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }
    }
}
