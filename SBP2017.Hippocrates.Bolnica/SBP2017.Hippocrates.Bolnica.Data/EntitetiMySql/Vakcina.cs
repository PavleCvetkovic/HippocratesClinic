using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql
{
    public class Vakcina
    {
        public virtual string Ime { get; set; }
        public virtual string Sifra { get; set; }
        public virtual string Opis { get; set; }

        public virtual IList<PrimioVakcinu> PrimioVakcinuPacijenti { get; set; }

        public Vakcina()
        {
            PrimioVakcinuPacijenti = new List<PrimioVakcinu>();
        }
    }
}
