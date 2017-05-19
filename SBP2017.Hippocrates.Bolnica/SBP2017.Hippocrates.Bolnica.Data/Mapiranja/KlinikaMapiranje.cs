using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class KlinikaMapiranje : ClassMap<Klinika>
    {
        public KlinikaMapiranje()
        {
            Table("KLINIKA");

            Id(x => x.Id)
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Telefon, "TELEFON");
            Map(x => x.Lokacija, "LOKACIJA");

            References(x => x.KlinickiCentar).Column("ID_KC").LazyLoad();

           
            References(x => x.GlavnaSestraKlinike).Column("ID_GLAVNE_SESTRE").LazyLoad();
            HasOne(x => x.Magacin).PropertyRef("Klinika").LazyLoad().Cascade.All();
            HasOne(x => x.ListaCekanja).PropertyRef("Klinika").LazyLoad().Cascade.All();
            HasMany(x => x.Pacijenti).KeyColumn("ID_KLINIKE").Cascade.All().Inverse().LazyLoad();
            HasMany(x => x.KoristiKrevete).KeyColumn("ID_KLINIKE").Cascade.All().LazyLoad();
        }
    }
}
