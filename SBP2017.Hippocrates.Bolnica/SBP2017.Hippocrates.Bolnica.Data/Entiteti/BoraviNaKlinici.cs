using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class BoraviNaKlinici
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime DatumPrijema { get; set; }
        public virtual int OcekivaniBoravak { get; set; }
        public virtual int BrojKreveta { get; set; }
        public virtual Klinika Klinika { get; set; }
        public virtual PacijentKlinickogCentra Pacijent { get; set; }
        public virtual DateTime? DatumOtpusta { get; set; }

    }
}
