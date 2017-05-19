using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Dobavljac
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }

        public virtual IList<PotrosniMaterijal> DobavljaMaterijal { get; set; }
        public virtual IList<KlinickiCentar> DobavljaZaKC { get; set; }

        public Dobavljac()
        {
            DobavljaMaterijal = new List<PotrosniMaterijal>();
            DobavljaZaKC = new List<KlinickiCentar>();
        }
    }
}
