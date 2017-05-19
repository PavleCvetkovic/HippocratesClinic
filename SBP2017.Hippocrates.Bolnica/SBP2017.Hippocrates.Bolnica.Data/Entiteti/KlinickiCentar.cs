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
        public virtual CentralniMagacin CentralniMagacin { get; set; }

        public virtual IList<Klinika> Klinike { get; set; }
        public virtual IList<Dobavljac> Dobavljaci { get; set; }
        public virtual IList<Ugovor> Ugovori { get; set; }
        public virtual IList<Krevet> Kreveti { get; set; }

        public KlinickiCentar()
        {
            Klinike = new List<Klinika>();
            Dobavljaci = new List<Dobavljac>();
            Ugovori = new List<Ugovor>();
            Kreveti = new List<Krevet>();
        }
    }
}
