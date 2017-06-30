
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class KrevetDto
    {
        public virtual int Id { get; set; }
        public virtual string Klinika { get; set; }
        public virtual string KlinickiCentar { get; set; }
    }
}
