using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects;
using NHibernate;

namespace WebAPI.Controllers
{
    public class KlinikaController : ApiController
    {
        [HttpGet]
        //[Route("api/GetKlinike")]
        public IEnumerable<KlinikaDto> GetKlinike()
        {
            ISession s = DataLayer.GetSession();

            
            //IEnumerable<KlinikaDto> klinike = new IEnumerable<KlinikaDto>();
            IQuery q = s.CreateQuery("from Klinika");
            IList<Klinika> klinike = q.List<Klinika>();
            List<KlinikaDto> klinikedto = new List<KlinikaDto>();
            foreach (Klinika k in klinike)
            {
                KlinikaDto kdto = new KlinikaDto()
                {
                    Id = k.Id,
                    Lokacija = k.Lokacija,
                    Naziv = k.Naziv,
                    Telefon = k.Telefon,
                    Id_KC = k.KlinickiCentar.Id
                };
                klinikedto.Add(kdto);
            }
            IEnumerable<KlinikaDto> klinikeDto = klinikedto;
            return klinikeDto;
            s.Close();
        }

        // GET api/<controller>/5
        [HttpGet]
       // [Route("api/KlinikaController/GetKlinika/{id}")]
        public KlinikaDto GetKlinika(int id)
        {
            ISession s = DataLayer.GetSession();
            Klinika k = s.Load<Klinika>(id);
            KlinikaDto kdto = new KlinikaDto()
            {
                Id = k.Id,
                Naziv = k.Naziv,
                Lokacija = k.Lokacija,
                Telefon = k.Telefon,
                Id_KC = k.KlinickiCentar.Id
            };
            s.Close();
            return kdto;
           
        }

        // POST api/<controller>
        [HttpPost]
        public void PostKlinika([FromBody]KlinikaDto kdto)
        {
            ISession s = DataLayer.GetSession();
            KlinikaDto k = kdto;
            Klinika klinika = new Klinika()
            {
                Id = k.Id,
                Naziv = k.Naziv,
                Lokacija = k.Lokacija,
                Telefon = k.Telefon,
                KlinickiCentar = s.Load<KlinickiCentar>(k.Id_KC)
            };
            s.Save(klinika);
            s.Flush();
            s.Close();
        }

        // PUT api/<controller>/5
        public void PutKlinika(int id, [FromBody]KlinikaDto kdto)
        {
            ISession s = DataLayer.GetSession();
            Klinika k = s.Load<Klinika>(id);
            k.Id = kdto.Id;
            k.Naziv = kdto.Naziv;
            k.Lokacija = kdto.Lokacija;
            k.Telefon = kdto.Telefon;
            KlinickiCentar kc = s.Load<KlinickiCentar>(kdto.Id_KC);
            k.KlinickiCentar = kc;
            s.Flush();
            s.Close();
        }

        // DELETE api/<controller>/5
        public void DeleteKlinika(int id)
        {
            ISession s = DataLayer.GetSession();
            Klinika k = s.Load<Klinika>(id);
            s.Delete(k);
            s.Close();
        }
    }
}