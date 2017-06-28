using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class PotrosniMaterijalDto
    {
        public virtual int Id { get;  set; }

        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual int CenaPoJedinici { get; set; }
        public virtual int KriticniNivoZaNarucivanje { get; set; }
        public virtual string TipMaterijala { get; set; }
        public virtual string NacinUzimanja { get; set; }
        public virtual string TipicnaDoza { get; set; }
        public virtual string NacinAdministracije { get; set; }
        public virtual int IdCentralniMagacin { get; set; }

    }
}
