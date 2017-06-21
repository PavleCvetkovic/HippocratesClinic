using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class ZaposleniDto
    {
        public virtual int IdKlinike { get; set; }
        public virtual int IdUgovora { get; set; }
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Pol { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string TipZaposlenog { get; set; }
        public virtual string Password { get; set; }
        public virtual string TipIsplate { get; set; }
        public virtual string TipUgovora { get; set; }
        public virtual int Plata { get; set; }
        public virtual int BrojSatiNedeljno { get; set; }
    }
}
