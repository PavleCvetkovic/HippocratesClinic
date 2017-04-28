using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Zaposleni
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
        public virtual string TipSestre { get; set; }
        public virtual string BrojOrdinacije { get; set; }
        public virtual Ugovor UgovorZaposlenog { get; set; }
        public virtual Klinika ZaposlenUKlinici { get; set; }
        public virtual string Password { get; protected set; }

        public virtual IList<Kvalifikacija> KvalifikacijeZaposlenog { get; set; }
        public virtual IList<Iskustvo> IskustvoZaposlenog { get; set; }
        public virtual IList<Smena> SmeneZaposlenog { get; set; }

        public Zaposleni()
        {
            KvalifikacijeZaposlenog = new List<Kvalifikacija>();
            IskustvoZaposlenog = new List<Iskustvo>();
            SmeneZaposlenog = new List<Smena>();
        }

    }
}
