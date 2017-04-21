using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class DomZdravlja
    {
        public virtual string MBR { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Opstina { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Lokacija { get; set; }

    }
}
