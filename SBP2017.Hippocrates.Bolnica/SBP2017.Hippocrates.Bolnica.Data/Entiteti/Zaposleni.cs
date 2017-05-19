using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public abstract class Zaposleni
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Pol { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string TipZaposlenog { get; set; }
        //public virtual string TipSestre { get; set; }
        //public virtual string BrojOrdinacije { get; set; }
        public virtual Ugovor Ugovor { get; set; }
        public virtual Klinika Klinika { get; set; }
        public virtual string Password { get; set; }
        public virtual IList<Kvalifikacija> Kvalifikacije { get; set; }
        public virtual IList<Iskustvo> Iskustva { get; set; }
        public virtual IList<Smena> Smene { get; set; }

        public Zaposleni()
        {
            Kvalifikacije = new List<Kvalifikacija>();
            Iskustva = new List<Iskustvo>();
            Smene = new List<Smena>();
        }

    }
    public class Specijalista : Zaposleni
    {
        public virtual string BrojOrdinacije { get; set; }
    }
    public class Sestra : Zaposleni
    {
        public virtual string TipSestre { get; set; }
    }
    public class PomocnoOsoblje : Zaposleni
    {

    }
    public class Bolnicar : Zaposleni
    {

    }
}
