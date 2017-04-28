using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Pregled
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Datum { get; set; }
        public virtual int Vreme { get; set; }
        public virtual string Prostorija { get; set; }
        //public virtual IzabraniLekar IzabraniLekarDZ { get; set; }
        public virtual Zaposleni LekarSpecijalista { get; set; }
        public virtual PacijentKlinickogCentra Pacijent { get; set; }
    }
}
