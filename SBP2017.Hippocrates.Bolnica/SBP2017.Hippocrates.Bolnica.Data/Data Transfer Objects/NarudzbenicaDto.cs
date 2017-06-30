using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class NarudzbenicaDto
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual string ImeKlinike { get; set; }
        public virtual DateTime DatumNarudzbine { get; set; }
        public virtual string ImeZaposlenog { get; set; }
        public virtual DateTime? DatumIsporuke { get; set; }
        public virtual int Cena { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual int IdKlinika { get; set; }
        public virtual int IdNaruceniMaterijal { get; set; }
    }
}
