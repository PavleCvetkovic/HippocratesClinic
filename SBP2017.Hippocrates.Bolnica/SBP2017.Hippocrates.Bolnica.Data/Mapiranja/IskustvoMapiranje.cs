using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class IskustvoMapiranje : ClassMap<Iskustvo>
    {
        public IskustvoMapiranje()
        {
            Table("ISKUSTVO");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
            Map(x => x.Institucija, "INSTITUCIJA");
            Map(x => x.Pozicija, "POZICIJA");

            References(x => x.Zaposleni, "ID_ZAPOSLENOG").Not.LazyLoad();

        }
    }
}
