using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class PacijentKlinickogCentra
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string BracniStatus { get; set; }
        public virtual string Pol { get; set; }
        public virtual string Adresa { get; set; }
        public virtual Rodjak Rodjak { get; set; }

        public virtual IList<BoraviNaKlinici> Klinike { get; set; }
        public virtual IList<PacijentiCekaju> ListeCekanja { get; set; }
        public virtual IList<Pregled> Pregledi { get; set; }
        public virtual IList<PacijentUzimaLekove> Lekovi { get; set; }

        public PacijentKlinickogCentra()
        {
            Lekovi = new List<PacijentUzimaLekove>();
            Klinike= new List<BoraviNaKlinici>();
            ListeCekanja = new List<PacijentiCekaju>();
            Pregledi = new List<Pregled>();
        }

    }
}
