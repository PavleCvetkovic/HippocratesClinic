using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class Krevet
    {
        public virtual int Id { get; protected set; }
        public virtual Klinika KrevetNaKlinici { get; set; }
        public virtual KlinickiCentar KrevetUKC { get; set; }

    }
}
