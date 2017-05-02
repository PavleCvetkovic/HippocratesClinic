using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Rodjak
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Srodstvo { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Telefon { get; set; }

        public virtual IList<PacijentKlinickogCentra> PacijentiUSrodstvu { get; set; }

        public Rodjak()
        {
            PacijentiUSrodstvu = new List<PacijentKlinickogCentra>();
        }
    }
}
