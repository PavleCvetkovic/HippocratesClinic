using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class MagacinKlinikeMapiranje : ClassMap<MagacinKlinike>
    {
        public MagacinKlinikeMapiranje()
        {
            Table("MAGACIN_KLINIKE");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.Klinika).Column("ID_KLINIKE").LazyLoad();

            HasMany(x => x.PotrosniMaterijal).KeyColumn("ID_MAGACINA").Cascade.All().Inverse();
        }
    }
}
