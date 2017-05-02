using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class PacijentiCekaju
    {
        public virtual int Id { get; protected set; }
        public virtual ListaCekanja ListaCekanja { get; set; }
        public virtual PacijentKlinickogCentra Pacijent { get; set; }
        public virtual DateTime DatumUpisa { get; set; }
        public virtual int OcekivanoVremeCekanja { get; set; }

    }
}
