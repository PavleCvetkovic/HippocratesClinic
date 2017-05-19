using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Ugovor
    {
        public virtual int Id { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual int BrojSatiNedeljno { get; set; }
        public virtual string TipIsplate { get; set; }
        public virtual string TipUgovora { get; set; }
        public virtual KlinickiCentar KlinickiCentar { get; set; }
        public virtual int Plata { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
    }
}
