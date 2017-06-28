using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class PregledDto
    {
        public virtual int Id { get;  set; }
        public virtual DateTime Datum { get; set; }
        public virtual int Vreme { get; set; }
        public virtual string Prostorija { get; set; }
        public virtual string IdIzabranogLekara { get; set; } //ide iz druge baze //CHECK // nullable  u bazi
        public virtual int IdSpecijalista { get; set; }
        public virtual int IdPacijent { get; set; }
    }
}
