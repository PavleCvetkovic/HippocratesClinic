using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class SmenaDto
    {
        public virtual int Id { get; set; }
        public virtual string DatumOd { get; set; }
        public virtual string DatumDo { get; set; }
        public virtual string ZaposlenImePrezime { get; set; }
        public virtual int IdZaposlenog { get; set; }
        public virtual string TipSmene { get; set; }
    }
}
