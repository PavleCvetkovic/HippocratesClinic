using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
namespace SBP2017.Hippocrates.Bolnica.Data.MapiranjaMySql
{
    public class PrimioVakcinuMapiranja : ClassMap<PrimioVakcinu>
    {
        public PrimioVakcinuMapiranja()
        {
            Table("PRIMIO_VAKCINU");

            CompositeId(x => x.Id)
                .KeyReference(x => x.PrimioPacijent, "JMBGP")
                .KeyReference(x => x.PrimioVakcina, "SIFRA_VAKCINE");

            Map(x => x.Datum, "DATUM");
        }
    }
}
