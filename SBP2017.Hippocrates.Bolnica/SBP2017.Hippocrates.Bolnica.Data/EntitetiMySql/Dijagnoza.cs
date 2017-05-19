using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql
{
    public class Dijagnoza
    {
        public virtual string Sifra { get; set; }
        public virtual string Ime { get; set; }

        public virtual IList<Dijagnostifikovano> Dijagnostifikovano { get; set; }
        public virtual IList<Terapija> Terapije { get; set; }

        public Dijagnoza()
        {
            Dijagnostifikovano = new List<Dijagnostifikovano>();
            Terapije = new List<Terapija>();
        }
        public override string ToString()
        {

            return this.Ime.ToString();
        }
    }
}
