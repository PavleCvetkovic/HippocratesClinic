using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class KvalifikacijaDto
    {
        public virtual int Id { get; set; }
        public virtual string Institucija { get; set; }
        public virtual string Vrsta { get; set; }
        //public virtual DateTime Datum { get; set; }
        public virtual int IdZaposleni { get; set; }

        public KvalifikacijaDto() { }
    }
}
