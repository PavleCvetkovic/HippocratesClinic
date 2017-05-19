using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql
{
    public class Terapija
    {
        public virtual int Id { get; protected set; }
        public virtual Pacijent TerapijaPacijent { get; set; }
        public virtual IzabraniLekar TerapijaLekar { get; set; }
        public virtual DateTime Datum_od { get; set; }
        public virtual DateTime Datum_do { get; set; }
        public virtual Dijagnoza TerapijaDijagnoza { get; set; }
        public virtual string Opis { get; set; }
    }
}
