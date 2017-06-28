using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class MagacinKlinikeSadrziDto
    {
        public virtual int Id { get; set; }
        public virtual int IdPotrosniMaterijal { get; set; }
        public virtual int IdMagacinKlinike { get; set; }
        public virtual int Kolicina { get; set; }
    }
}
