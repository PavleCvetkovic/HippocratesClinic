using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Pregled
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Datum { get; set; }
        public virtual int Vreme { get; set; }
        public virtual string Prostorija { get; set; }
        public virtual string IdIzabranogLekara { get; set; } //ide iz druge baze //CHECK
        public virtual Zaposleni Specijalista { get; set; }
        public virtual PacijentKlinickogCentra Pacijent { get; set; }
    }
}
