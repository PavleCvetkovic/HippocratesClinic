using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Dobavlja
    {
        public virtual PotrosniMaterijal MaterijalZaDobavljanje{get; set; }
        public virtual Dobavljac DobavljacMaterijala { get; set; }

    }
}
