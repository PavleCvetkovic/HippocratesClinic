using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class MagacinKlinikeSadrzi
    {
        public virtual MagacinKlinike MagKlinike { get; set; }
        public virtual PotrosniMaterijal PotrosniMaterijalUMagacinu { get; set; }

    }
}
