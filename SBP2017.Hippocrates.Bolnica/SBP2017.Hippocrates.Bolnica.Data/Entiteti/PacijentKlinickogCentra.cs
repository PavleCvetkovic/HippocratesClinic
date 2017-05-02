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
        public virtual Rodjak RodjakPacijenta { get; set; }

        public virtual IList<PotrosniMaterijal> LekoviPacijenta { get; set; }
        public virtual IList<BoraviNaKlinici> PacijentBoraviNaKlinikama { get; set; }
        public virtual IList<PacijentiCekaju> PacijentListeCekanja { get; set; }

        public PacijentKlinickogCentra()
        {
            LekoviPacijenta = new List<PotrosniMaterijal>();
            PacijentBoraviNaKlinikama = new List<BoraviNaKlinici>();
            PacijentListeCekanja = new List<PacijentiCekaju>();
        }

    }
}
