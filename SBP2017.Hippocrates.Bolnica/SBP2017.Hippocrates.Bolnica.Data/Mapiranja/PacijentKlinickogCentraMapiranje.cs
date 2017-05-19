using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class PacijentKlinickogCentraMapiranje:ClassMap<PacijentKlinickogCentra>
    {
        public PacijentKlinickogCentraMapiranje()
        {
            Table("PACIJENT_KLINICKOG_CENTRA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.JMBG, "JMBG");
            Map(x => x.BracniStatus, "BRACNI_STATUS");
            Map(x => x.Pol, "POL");
            Map(x => x.Adresa, "ADRESA");

            References(x => x.Rodjak).Column("ID_RODJAKA").LazyLoad();

            HasMany(x => x.Lekovi).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse().LazyLoad();
            HasMany(x => x.Pregledi).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse().LazyLoad();
            HasMany(x => x.Klinike).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse().LazyLoad();
            HasMany(x => x.ListeCekanja).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse().LazyLoad();
        }
    }
}
