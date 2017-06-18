using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class MagacinKlinikeSadrzi
    {
        public virtual int Id { get; protected set; }
        public virtual PotrosniMaterijal PotrosniMaterijal { get; set; }
        public virtual MagacinKlinike MagacinKlinike { get; set; }
        public virtual int Kolicina { get; set; }
    }
}
