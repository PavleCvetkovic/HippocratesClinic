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

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");

            References(x => x.Pacijent).Column("ID_PACIJENTA").Not.LazyLoad();
            References(x => x.Lek).Column("ID_LEKA").Not.LazyLoad();
        }
    }
}
