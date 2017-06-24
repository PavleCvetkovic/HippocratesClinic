using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class UgovorDto
    {
        public virtual int Id { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual int BrojSatiNedeljno { get; set; }
        public virtual string TipIsplate { get; set; }
        public virtual string TipUgovora { get; set; }
        public virtual int IdKlinickogCentra { get; set; }
        public virtual int Plata { get; set; }
        public virtual int IdZaposlenog { get; set; }
    }
}
