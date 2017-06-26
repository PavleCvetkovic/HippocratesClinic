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

#region Prioritet prema kojem se trazi odgovarajuca funkcija za odgovarajuci METOD (Get, Post...) 
//1.If there is an attribute applied(via[HttpGet], [HttpPost], [HttpPut], [AcceptVerbs], etc), the action will accept the specified HTTP method(s).
//2.If the name of the controller action starts the words "Get", "Post", "Put", "Delete", "Patch", "Options", or "Head", use the corresponding HTTP method.
//3.Otherwise, the action supports the POST method.
#endregion

namespace WebAPI.Controllers
{
    public class KlinikaController : ApiController
    {
        #region Prethodno kodiranje (inicijalno)
        //[HttpGet]
        ////[Route("api/controller/method")]
        //public IEnumerable<KlinikaDto> GetKlinike()
        //{
        //    ISession s = DataLayer.GetSession();


        //    //IEnumerable<KlinikaDto> klinike = new IEnumerable<KlinikaDto>();
        //    IQuery q = s.CreateQuery("from Klinika");
        //    IList<Klinika> klinike = q.List<Klinika>();
        //    List<KlinikaDto> klinikedto = new List<KlinikaDto>();
        //    foreach (Klinika k in klinike)
        //    {
        //        KlinikaDto kdto = new KlinikaDto()
        //        {
        //            Id = k.Id,
        //            Lokacija = k.Lokacija,
        //            Naziv = k.Naziv,
        //            Telefon = k.Telefon,
        //            Id_KC = k.KlinickiCentar.Id
        //        };
        //        klinikedto.Add(kdto);
        //    }
        //    IEnumerable<KlinikaDto> klinikeDto = klinikedto;
        //    return klinikeDto;
        //    s.Close();
        //}

        // GET api/<controller>/5
        //[HttpGet]
        // [Route("api/KlinikaController/GetKlinika/{id}")]
        //public KlinikaDto GetKlinika(int id)
        //{
        //    ISession s = DataLayer.GetSession();
        //    Klinika k = s.Load<Klinika>(id);
        //    KlinikaDto kdto = new KlinikaDto()
        //    {
        //        Id = k.Id,
        //        Naziv = k.Naziv,
        //        Lokacija = k.Lokacija,
        //        Telefon = k.Telefon,
        //        Id_KC = k.KlinickiCentar.Id
        //    };
        //    s.Close();
        //    return kdto;

        //}

        // POST api/<controller>
        //[HttpPost]
        //public void PostKlinika([FromBody]KlinikaDto kdto)
        //{
        //    ISession s = DataLayer.GetSession();
        //    KlinikaDto k = kdto;
        //    Klinika klinika = new Klinika()
        //    {
        //        Id = k.Id,
        //        Naziv = k.Naziv,
        //        Lokacija = k.Lokacija,
        //        Telefon = k.Telefon,
        //        KlinickiCentar = s.Load<KlinickiCentar>(k.Id_KC)
        //    };
        //    s.Save(klinika);
        //    s.Flush();
        //    s.Close();
        //}

        // PUT api/<controller>/5
        //public void PutKlinika(int id, [FromBody]KlinikaDto kdto)
        //{
        //    ISession s = DataLayer.GetSession();
        //    Klinika k = s.Load<Klinika>(id);
        //    k.Id = kdto.Id;
        //    k.Naziv = kdto.Naziv;
        //    k.Lokacija = kdto.Lokacija;
        //    k.Telefon = kdto.Telefon;
        //    KlinickiCentar kc = s.Load<KlinickiCentar>(kdto.Id_KC);
        //    k.KlinickiCentar = kc;
        //    s.Flush();
        //    s.Close();
        //}

        //// DELETE api/<controller>/5
        //public void DeleteKlinika(int id)
        //{
        //    ISession s = DataLayer.GetSession();
        //    Klinika k = s.Load<Klinika>(id);
        //    /* IQuery iq = s.CreateQuery("select o from Ugovor as o where o.KlinickiCentar.Id = : IDK");
        //     iq.SetString("IDK", k.KlinickiCentar.Id.ToString());
        //     IList<Ugovor> ugovori = iq.List<Ugovor>();
        //     foreach(Ugovor u in ugovori)
        //     {
        //         s.Delete(u);

        //     }
        //    */
        //    if (k.GlavnaSestraKlinike != null)
        //    {
        //        Zaposleni z = k.GlavnaSestraKlinike;
        //        z.Klinika = s.Load<Klinika>(84);
        //        k.GlavnaSestraKlinike = null;
        //    }

        //    if(k.Magacin != null)
        //        s.Delete(k.Magacin);
        //    k.ListaCekanja.Pacijenti = null;
        //    s.Delete(k.ListaCekanja);
        //    foreach(Narudzbenica n in k.Narudzbenice)
        //    {
        //        s.Delete(n);
        //    }
        //    foreach(Krevet kr in k.KoristiKrevete)
        //    {
        //        s.Delete(kr);
        //    }
        //    foreach(BoraviNaKlinici br in k.Pacijenti)
        //    {
        //        br.Pacijent.Klinike.Remove(br);
        //        s.Delete(br);
        //    }
        //    s.Delete(k);
        //    s.Flush();
        //    s.Close();
        //}
        #endregion

        [HttpGet] // se podrazumeva (jer metod pocinje sa "Get" tekstom) // vidi pojasnjenje u "using" delu (goree ^)
        public IHttpActionResult Get([FromUri] int id)
        {
            ISession s = DataLayer.GetSession();
            IList<Klinika> kl = s.QueryOver<Klinika>().Where(x => x.Id == id).List();
            Klinika k = kl[0];
            //Klinika k = s.Get<Klinika>(id);  // Koristi se GET metod. (jer on proverava postojanje objekta u bazi)
            #region Objasnjenje zasto se koristi get metod
                //Load should be used when you know for sure that an entity with a certain ID exists.
                //The call does not result in a database hit(and thus can be optimized away by NHibernate in certain cases).
                //Beware of the exception that may be raised when the object is accessed if the entity instance doesn't exist in the DB.

                //Get hits the database or session cache to retrieve the entity data. 
                //If the entity exists it is returned, otherwise null will be returned.
                //This is the safest way to determine whether an entity with a certain ID exists or not.
                //If you're not sure what to use, use Get.
            #endregion

            if (k == null) // Provera da li je sesija vratila objekat (da li objekat postoji u bazi)
                //return NotFound(); // Vraca se prazna poruka (moze da se customize-uje da vraca neku poruku) 
                return Content(HttpStatusCode.NotFound, "Trazeni objekat sa ID: " + id + " ne postoji");


            KlinikaDto kdto = new KlinikaDto()
            {
                Id = k.Id,
                Naziv = k.Naziv,
                Lokacija = k.Lokacija,
                Telefon = k.Telefon,
                Id_KC = k.KlinickiCentar.Id
            };
            s.Close();
            return Ok(kdto);
        }

        [HttpGet]
        //[Route("api/controller/method")]
        public IHttpActionResult GetAll()
        {
            ISession s = DataLayer.GetSession();
            //IEnumerable<KlinikaDto> klinike = new IEnumerable<KlinikaDto>();
            //IQuery q = s.CreateQuery("from Klinika");
            //IList<Klinika> klinike = q.List<Klinika>();
            IList<Klinika> klinike = s.QueryOver<Klinika>().List<Klinika>();
            if (klinike.Count == 0) // nema objekata
                return Content(HttpStatusCode.NoContent, "Nema trazenih rezultata");
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
            //IEnumerable<KlinikaDto> klinikeDto = klinikedto;
            s.Close();
            //return Ok(klinikeDto);
            return Ok(klinikedto);
        }

        [HttpPost] // Nije neophodno, metod pocinje sa "Post"
        public IHttpActionResult Post([FromBody]KlinikaDto kdto)
        {
            ISession s = DataLayer.GetSession();
            KlinikaDto k = kdto;
            Klinika klinika = new Klinika()
            {
                Id = k.Id,
                Naziv = k.Naziv,
                Lokacija = k.Lokacija,
                Telefon = k.Telefon,
                KlinickiCentar = s.Get<KlinickiCentar>(k.Id_KC)
            };
            if (klinika.KlinickiCentar == null)
                    return Content(HttpStatusCode.NotFound, "Klinicki centar sa upisanim ID: " + k.Id + " ne postoji");
            try
            {
                s.Save(klinika);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Greska prilikom upisivanja u bazu podataka " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Objekat je upisan u bazu");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]KlinikaDto kdto)
        {
            ISession s = DataLayer.GetSession();
            //Klinika k = s.Get<Klinika>(id); // Zasto se koristi GET metoda objasnjeno je u GetKlinika funkciji
            IList<Klinika> kl = s.QueryOver<Klinika>().Where(x => x.Id == id).List();
            Klinika k = kl[0];

            if (k == null) // Provera da li je sesija vratila objekat (da li objekat postoji u bazi)
                return Content(HttpStatusCode.NotFound, "Trazeni objekat sa ID: " + id + " ne postoji");
            k.Id = kdto.Id;
            k.Naziv = kdto.Naziv;
            k.Lokacija = kdto.Lokacija;
            k.Telefon = kdto.Telefon;
            KlinickiCentar kc = s.Get<KlinickiCentar>(kdto.Id_KC);
            if (kc == null)
                return Content(HttpStatusCode.NotFound, "Klinicki centar sa upisanim ID: " + id + " ne postoji");
            k.KlinickiCentar = kc;
            try
            {
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Greska prilikom upisivanja u bazu podataka " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Objekat je azuriran/upisan u bazu");
        }

        // DELETE api/<controller>/5
        [HttpDelete] // nije neophodno jer metod pocinje sa "Delete..."
        public IHttpActionResult Delete(int id)
        {
            ISession s = DataLayer.GetSession();
            IList<Klinika> kl = s.QueryOver<Klinika>().Where(x => x.Id == id).List();
            Klinika k = kl[0];

            //Klinika k = s.Get<Klinika>(id);
            //IList<Klinika> k = s.QueryOver<Klinika>().Where(x => x.Id == id).List<Klinika>();
            if (k == null) // Provera da li je sesija vratila objekat (da li objekat postoji u bazi)
                return Content(HttpStatusCode.NotFound, "Trazeni objekat sa ID: " + id + " ne postoji");
            /* IQuery iq = s.CreateQuery("select o from Ugovor as o where o.KlinickiCentar.Id = : IDK");
             iq.SetString("IDK", k.KlinickiCentar.Id.ToString());
             IList<Ugovor> ugovori = iq.List<Ugovor>();
             foreach(Ugovor u in ugovori)
             {
                 s.Delete(u);

             }
             
            */

            if (k.GlavnaSestraKlinike != null)
            {
                Zaposleni z = k.GlavnaSestraKlinike;
                z.Klinika = s.Load<Klinika>(84);
                k.GlavnaSestraKlinike = null;
            }

            if (k.Magacin != null)
                s.Delete(k.Magacin);
            k.ListaCekanja.Pacijenti = null;
            s.Delete(k.ListaCekanja);
            try
            {
                foreach (Narudzbenica n in k.Narudzbenice)
                {
                    s.Delete(n);
                }
                foreach (Krevet kr in k.KoristiKrevete)
                {
                    s.Delete(kr);
                }
                foreach (BoraviNaKlinici br in k.Pacijenti)
                {
                    br.Pacijent.Klinike.Remove(br);
                    s.Delete(br);
                }
                s.Delete(k);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Greska brisanja iz baze podataka " + ex.Message);
            }
            return Content(HttpStatusCode.OK, "Objekat je obrisan iz baze");
        }
    }
}