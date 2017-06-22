using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class PacijentKlinickogCentraDto
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string DatumRodjenja { get; set; }
        public virtual string JMBG { get; set; }
        public virtual string BracniStatus { get; set; }
        public virtual string Pol { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Rodjak { get; set; }
        public virtual int RodjakId { get; set; }
        public PacijentKlinickogCentraDto()
        {

        }
    }
}
