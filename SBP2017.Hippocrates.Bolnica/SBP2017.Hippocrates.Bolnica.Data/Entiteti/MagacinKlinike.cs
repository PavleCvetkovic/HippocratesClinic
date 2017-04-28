using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class MagacinKlinike
    {
        public virtual int Id { get; protected set; }
        public virtual Klinika MagacinNaKlinici { get; set; }

        public virtual IList<PotrosniMaterijal> MaterijalUMagacinu { get; set; }

        public MagacinKlinike()
        {
            MaterijalUMagacinu = new List<PotrosniMaterijal>();
        }

    }
}
