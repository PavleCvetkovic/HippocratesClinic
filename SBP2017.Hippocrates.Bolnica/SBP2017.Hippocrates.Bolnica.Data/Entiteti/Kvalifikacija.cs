using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Kvalifikacija
    {
        public virtual int Id { get; set; }
        public virtual string Institucija { get; set; }
        public virtual string Vrsta { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual Zaposleni KvalifikacijaZaposlenog { get; set; }

    }
}
