using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class SmenaMapiranje : ClassMap<Smena>
    {
        public SmenaMapiranje()
        {
            Table("SMENA");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
            Map(x => x.TipSmene, "TIP_SMENE");

            References(x => x.Zaposleni, "ID_ZAPOSLENOG").LazyLoad();

        }
    }
}
