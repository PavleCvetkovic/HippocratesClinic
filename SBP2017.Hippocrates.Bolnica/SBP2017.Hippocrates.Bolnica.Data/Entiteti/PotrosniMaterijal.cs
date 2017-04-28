using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class PotrosniMaterijal
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual int CenaPoJedinici { get; set; }
        public virtual int KriticniNivoZaNarucivanje { get; set; }
        public virtual string TipMaterijala { get; set; }
        public virtual string NacinUzimanja { get; set; }
        public virtual string TipicnaDoza { get; set; }
        public virtual string NacinAdministracije { get; set; }
        public virtual CentralniMagacin CentralniMag { get; set; }

        public virtual IList<MagacinKlinike> MagaciniSaMaterijalom { get; set; }
        public virtual IList<Dobavljac> MaterijalDobavljaju { get; set; }
        public virtual IList<PacijentKlinickogCentra> PacijetniUzimajuLek { get; set; }

        public PotrosniMaterijal()
        {
            MagaciniSaMaterijalom = new List<MagacinKlinike>();
            MaterijalDobavljaju = new List<Dobavljac>();
            PacijetniUzimajuLek = new List<PacijentKlinickogCentra>();
        }
}
