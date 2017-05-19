using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql
{
    public class PrimioVakcinuId
    {
        public virtual Pacijent PrimioPacijent { get; set; }
        public virtual Vakcina PrimioVakcina { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return PrimioVakcina.Ime + " " + PrimioVakcina.Opis;
        }
    }
}
