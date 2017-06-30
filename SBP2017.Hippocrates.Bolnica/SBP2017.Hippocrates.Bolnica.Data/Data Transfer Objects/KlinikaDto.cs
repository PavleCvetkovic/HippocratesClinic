using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class KlinikaDto
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual int Id_KC { get; set; }
    }
}
