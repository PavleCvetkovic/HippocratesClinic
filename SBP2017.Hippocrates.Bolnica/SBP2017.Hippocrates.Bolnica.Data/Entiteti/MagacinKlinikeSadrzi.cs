using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class MagacinKlinikeSadrzi
    {
        public int Id { get; protected set; }
        public PotrosniMaterijal PotrosniMaterijal { get; set; }
        public MagacinKlinike MagacinKlinike { get; set; }
        public int Kolicina { get; set; }
    }
}
