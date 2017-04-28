using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class PacijentUzimaLekove
    {
        public virtual PacijentUzimaLekoveId Id { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime DatumDo { get; set; }

        public PacijentUzimaLekove()
        {
            Id = new PacijentUzimaLekoveId();            
        }
    }
}
