using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class ListaCekanjaMapiranje : ClassMap<ListaCekanja>
    {
        public ListaCekanjaMapiranje()
        {
            Table("LISTA_CEKANJA");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.Klinika).Column("ID_KLINIKE").LazyLoad();

            HasMany(x => x.Pacijenti).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse().LazyLoad();
        }
    }
}
