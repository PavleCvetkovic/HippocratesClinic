using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class KlinickiCentar
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual Zaposleni DirektorKlinickogCentra { get; set; }

        public virtual IList<Klinika> Klinike { get; set; }
        public virtual IList<Dobavljac> KCKupujeODobavljaca { get; set; }\
        public virtual IList<Ugovor> UgovoriKC { get; set; }

        public KlinickiCentar()
        {
            Klinike = new List<Klinika>();
            KCKupujeODobavljaca = new List<Dobavljac>();
            UgovoriKC = new List<Ugovor>();
        }
    }
}
