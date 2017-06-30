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
    public class CentralniMagacinController : ApiController
    {
        // GET: api/CentralniMagacin
        public IHttpActionResult GetAll()
        {
            ISession s = DataLayer.GetSession();
            IList<CentralniMagacin> magacini = s.QueryOver<CentralniMagacin>().List();
            if (magacini.Count == 0)
                return Content(HttpStatusCode.NoContent, "Nema rezultata");
            List<CentralniMagacinDto> magaciniDTO = new List<CentralniMagacinDto>();
            foreach (CentralniMagacin cm in magacini)
            {
                CentralniMagacinDto cmDTO = new CentralniMagacinDto()
                {
                    Id = cm.Id,
                    IdKlinickiCentar = cm.KlinickiCentar.Id
                };
                magaciniDTO.Add(cmDTO);
            }
            s.Close();
            return Content(HttpStatusCode.OK, magaciniDTO);
        }

        // GET: api/CentralniMagacin/5
        public IHttpActionResult Get(int id)
        {
            ISession s = DataLayer.GetSession();
            CentralniMagacin cm = s.Get<CentralniMagacin>(id);
            if (cm == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata sa ID: " + id);
            CentralniMagacinDto dto = new CentralniMagacinDto();
            dto.Id = cm.Id;
            dto.IdKlinickiCentar = cm.KlinickiCentar.Id;
            s.Close();
            return Content(HttpStatusCode.OK, dto);

        }

        // POST: api/CentralniMagacin
        public IHttpActionResult Post([FromBody]CentralniMagacinDto value)
        {
          //  return Content(HttpStatusCode.NotImplemented, "Ne radi jos uvek");
            ISession s = DataLayer.GetSession();
            //IList<KlinickiCentar> klinicki = s.QueryOver<KlinickiCentar>().List();
            //KlinickiCentar kc = klinicki[0];/ // Vise instanci KlinickihCentara
            KlinickiCentar kc = s.Get<KlinickiCentar>(value.IdKlinickiCentar);
            if (kc == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata (KlinickiCentar) sa ID: " + value.IdKlinickiCentar);
            CentralniMagacin cm = new CentralniMagacin()
            {
               KlinickiCentar = kc
            };
            try
            {
                s.Save(cm);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                s.Close();
                return Content(HttpStatusCode.BadRequest, "Greska prilikom upisa u bazu " +
                  ex.Message);
            }
            return Content(HttpStatusCode.OK, "Uspesno upisan objekat u bazu");
        }

        // PUT: api/CentralniMagacin/5
        public IHttpActionResult Put(int id, [FromBody]CentralniMagacinDto value)
        {
            //return Content(HttpStatusCode.NotImplemented, "Ne radi jos uvek");

            ISession s = DataLayer.GetSession();
            CentralniMagacin cm = s.Get<CentralniMagacin>(id);
            if (cm == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata (CentralniMagacin) sa ID: " + id);
            //IList<KlinickiCentar> klinicki = s.QueryOver<KlinickiCentar>().List();
            //KlinickiCentar kc = klinicki[0];/*s.Get<KlinickiCentar>(value.IdKlinickiCentar);*/ // Vise instanci KlinickihCentara
            KlinickiCentar kc = s.Get<KlinickiCentar>(value.IdKlinickiCentar);
            if (kc == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata (KlinickiCentar) sa ID: " + value.IdKlinickiCentar);

            cm.KlinickiCentar = kc;
            try
            {
                s.SaveOrUpdate(cm);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                s.Close();
                return Content(HttpStatusCode.BadGateway, "Greska prilikom upisa u bazu " +
                ex.Message);
            }
            return Content(HttpStatusCode.OK, "Uspesno azuriran/kreiran objekat");
        }

        // DELETE: api/CentralniMagacin/5
        public IHttpActionResult Delete(int id)
        {
            // Radi kako treba
            ISession s = DataLayer.GetSession();
            CentralniMagacin cm = s.Get<CentralniMagacin>(id);
            if (cm == null)
                return Content(HttpStatusCode.NotFound, "Nema rezultata (CentralniMagacin) sa ID: " + id);
            try
            {
                s.Delete(cm);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                s.Close();
                return Content(HttpStatusCode.BadGateway, "Greska brisanja iz baze " +
                ex.Message);
            }
            return Content(HttpStatusCode.OK, "Uspesno obrisan objekat");


        }
    }
}
