using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using SBP2017.Hippocrates.Bolnica.Data.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class NarudzbenicaController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            IList<NarudzbenicaDto> listDto = NarudzbenicaDataProvider.GetAll();
            if (listDto.Count == 0)
                return Content(HttpStatusCode.NotFound, "Nema rezultata");
            return Content(HttpStatusCode.OK, listDto);
        }

        public IHttpActionResult Get(int id)
        {

            bool found = true;
            NarudzbenicaDto d = NarudzbenicaDataProvider.Get(id, out found);
            if (!found)
                return Content(HttpStatusCode.NotFound, "Nema rezultata za trazeni ID: " + id);
            return Content(HttpStatusCode.OK, d);
        }


        public IHttpActionResult Post([FromBody]NarudzbenicaDto value)
        {
            string s = "";
            if (NarudzbenicaDataProvider.Add(value, out s))
                return Content(HttpStatusCode.Created, s);
            return Content(HttpStatusCode.BadRequest, s);

        }

        public IHttpActionResult Put(int id, [FromBody]NarudzbenicaDto value)
        {
            string st = "";
            if (NarudzbenicaDataProvider.Update(id, value, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }


        public IHttpActionResult Delete(int id)
        {
            string st = "";
            if (NarudzbenicaDataProvider.Delete(id, out st))
                return Content(HttpStatusCode.OK, st);
            else
                return Content(HttpStatusCode.BadRequest, st);
        }
    }
}
