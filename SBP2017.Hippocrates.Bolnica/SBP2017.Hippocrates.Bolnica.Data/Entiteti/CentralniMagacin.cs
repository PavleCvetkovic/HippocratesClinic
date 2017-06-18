using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class CentralniMagacin
    {
        public virtual int Id { get; protected set; }
        public virtual KlinickiCentar KlinickiCentar { get; set; }

        public virtual IList<PotrosniMaterijal> Materijal { get; set; }

        public CentralniMagacin()
        {
            Materijal = new List<PotrosniMaterijal>();
        }
    }
}
