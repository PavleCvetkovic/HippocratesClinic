using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class BoraviNaKlinici
    {
        public virtual BoraviNaKliniciId Id { get; set; }
        public virtual DateTime DatumPrijema { get; set; }
        public virtual int OcekivaniBoravak { get; set; }
        public virtual Krevet KrevetPacijenta { get; set; }
        public virtual DateTime DatumOtpusta { get; set; }

        public BoraviNaKlinici()
        {
            Id = new BoraviNaKliniciId();
        }

    }
}
