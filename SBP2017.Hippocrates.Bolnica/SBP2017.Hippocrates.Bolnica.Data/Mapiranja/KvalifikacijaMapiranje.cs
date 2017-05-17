using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class KvalifikacijaMapiranje : ClassMap<Kvalifikacija>
    {
        public KvalifikacijaMapiranje()
        {
            Table("KVALIFIKACIJA");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Institucija, "INSTITUCIJA");
            Map(x => x.Vrsta, "VRSTA");
            Map(x => x.Datum, "DATUM");

            References(x => x.Zaposleni, "ID_ZAPOSLENOG").Not.LazyLoad();
        }
    }
}
