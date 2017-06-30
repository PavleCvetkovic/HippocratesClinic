using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class KlinickiCentarDto
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual int IdDirektorKlinickogCentra { get; set; }
        public virtual int IdCentralniMagacin { get; set; }

        //public KlinickiCentarDto() { }

    }
}
