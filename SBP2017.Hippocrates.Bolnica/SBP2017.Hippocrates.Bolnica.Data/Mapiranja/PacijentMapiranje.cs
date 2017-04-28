using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class PacijentMapiranje : ClassMap<PacijentKlinickogCentra>
    {
        public PacijentMapiranje()
        {                     
            Table("PACIJENT_KLINICKOG_CENTRA");

            Id(x => x.Id, "ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.JMBG, "JMBG");
            Map(x => x.BracniStatus,"BRACNI_STATUS");
            Map(x => x.Pol, "POL");
            Map(x => x.Adresa, "ADRESA");

            References(x => x.RodjakPacijenta).Column("ID_RODJAKA").LazyLoad();

            HasMany(x => x.LekoviPacijenta).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse();
            HasMany(x => x.PacijentBoraviNaKlinici).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse();
            HasMany(x => x.PacijentListeCekanja).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse();

        }
    }
}
