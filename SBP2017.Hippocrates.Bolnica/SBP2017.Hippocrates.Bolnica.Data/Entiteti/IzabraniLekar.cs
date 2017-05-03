using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//PREDSTAVLJA EVIDENCIJU LEKARA KOJI SU PISALI UPUTE ZA NEKOG SPEC
//SVI IZABRANI LEKARI SE NALAZE U MYSQL BAZI!
namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class IzabraniLekar
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Adresa { get; set; }
        public virtual DomZdravlja DomZdravlja { get; set; }
    }
}
