using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class KrevetMapiranje : ClassMap<Krevet>
    {
        public KrevetMapiranje()
        {
            Table("KREVET");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.KrevetNaKlinici).Column("ID_KLINIKE").LazyLoad();
            References(x => x.KrevetUKC).Column("ID_KC").LazyLoad();

        }
    }
}
