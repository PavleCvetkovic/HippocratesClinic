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
        public virtual KlinickiCentar KlinickiCentar { get; set; }
        public virtual MagacinKlinike Magacin { get; set; }
        public virtual ListaCekanja ListaCekanja { get; set; }

        public virtual IList<Narudzbenica> Narudzbenice { get; set; }
        public virtual IList<Krevet> KoristiKrevete { get; set; }
        public virtual IList<BoraviNaKlinici> Pacijenti { get; set; }

        public Klinika()
        {
            Pacijenti= new List<BoraviNaKlinici>();
            KoristiKrevete = new List<Krevet>();
            Narudzbenice = new List<Narudzbenica>();
        }

    }
}
