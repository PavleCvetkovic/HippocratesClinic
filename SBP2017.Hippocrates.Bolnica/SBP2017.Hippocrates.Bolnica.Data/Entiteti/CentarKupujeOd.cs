using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class CentarKupujeOd
    {
        public virtual KlinickiCentar KCentar { get; set; }
        public virtual Dobavljac DobavljacKCentra { get; set; }

    }
}
