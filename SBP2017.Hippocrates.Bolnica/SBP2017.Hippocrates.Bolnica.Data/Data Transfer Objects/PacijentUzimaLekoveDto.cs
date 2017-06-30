using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class PacijentUzimaLekoveDto
    {
        public virtual int Id { get;  set; }
        public virtual int IdPacijent { get; set; }
        public virtual int IdLek { get; set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime DatumDo { get; set; }
    }
}
