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
    public class IskustvoController : ApiController
    {
        // GET: api/Iskustvo
        public IHttpActionResult GetAll()
        {
            IList<IskustvoDto> listDto = IskustvoDataProvider.GetAll();
            if (listDto.Count == 0)
                return Content(HttpStatusCode.NotFound, "Nema rezultata");
            return Content(HttpStatusCode.OK, listDto);
        }

        // GET: api/Iskustvo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Iskustvo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Iskustvo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Iskustvo/5
        public void Delete(int id)
        {
        }
    }
}
