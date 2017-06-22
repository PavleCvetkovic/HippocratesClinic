using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class BoraviNaKliniciDto
    {
        public virtual int Id { get; set; }
        //public virtual DateTime DatumPrijema { get; set; }
        public virtual int OcekivaniBoravak { get; set; }
        public virtual int BrojKreveta { get; set; }
        public virtual int IdKlinika { get; set; }
        public virtual int IdPacijentKlinickogCentra { get; set; }
        //public virtual DateTime? DatumOtpusta { get; set; }
    }
}
