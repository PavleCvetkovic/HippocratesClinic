using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Narudzbenica
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual string ImeKlinike { get; set; }
        public virtual DateTime DatumNarudzbine { get; set; }
        public virtual string ImeZaposlenog { get; set; }
        public virtual DateTime DatumIsporuke { get; set; }
        public virtual int Cena { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual Klinika Klinika { get; set; }
        public virtual PotrosniMaterijal NaruceniMaterijal { get; set; }

    }
}
