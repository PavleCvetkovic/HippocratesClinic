using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Klinika
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual Zaposleni GlavnaSestraKlinike { get; set; }
        public virtual KlinickiCentar KCKlinike { get; set; }

    }
}
