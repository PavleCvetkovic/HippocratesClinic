using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//PREDSTAVLJA SAMO EVIDENCIJU DOMOVA ZDRAVLJA IZ KOJIH SU LEKARI PISALI UPUTE...
//SVI DOMOVI SE CUVAJU U MYSQL BAZI!
namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class DomZdravlja
    {
        public virtual string MBR { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Opstina { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Lokacija { get; set; }

        public virtual IList<IzabraniLekar> IzabraniLekari { get; set; }
        
        public DomZdravlja()
        {
            IzabraniLekari = new List<IzabraniLekar>();
        }
    }
}
