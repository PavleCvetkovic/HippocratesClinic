using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class PacijentUzimaLekoveMapiranje : ClassMap<PacijentUzimaLekove>
    {
        public PacijentUzimaLekoveMapiranje()
        {
            Table("PACIJENT_UZIMA_LEKOVE");

            CompositeId(x => x.Id)
                .KeyReference(x => x.Pacijent, "ID_PACIJENTA")
                .KeyReference(x => x.Lek, "ID_LEKA");

            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
        }
    }
}
