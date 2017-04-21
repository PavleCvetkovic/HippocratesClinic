using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Iskustvo
    {
        public virtual int Id { get; set; }
        public virtual Zaposleni IskustvoZaposlenog { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime DatumDo { get; set; }
        public virtual string Institucija { get; set; }
        public virtual string Pozicija { get; set; }

    }
}
