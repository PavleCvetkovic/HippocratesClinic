using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class KlinickiCentarMapiranje : ClassMap<KlinickiCentar>
    {
        public KlinickiCentarMapiranje()
        {
            Table("KLINICKI_CENTAR");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Lokacija);

            References(x => x.DirektorKlinickogCentra).Column("ID_DIREKTORA");
            HasMany(x => x.Klinike).KeyColumn("ID_KC").Inverse().Cascade.All().LazyLoad();
            HasMany(x => x.Ugovori).KeyColumn("ID_KC").Inverse().Cascade.All().LazyLoad();
            HasMany(x => x.Kreveti).KeyColumn("ID_KC").Inverse().Cascade.All().LazyLoad();
            HasOne(x => x.CentralniMagacin).PropertyRef("KlinickiCentar").Cascade.All();
            HasManyToMany(x => x.Dobavljaci)
                .Table("CENTAR_KUPUJE_OD")
                .ParentKeyColumn("ID_KC")
                .ChildKeyColumn("ID_DOBAVLJACA")
                .Inverse().Cascade.All();

        }
    }
}
