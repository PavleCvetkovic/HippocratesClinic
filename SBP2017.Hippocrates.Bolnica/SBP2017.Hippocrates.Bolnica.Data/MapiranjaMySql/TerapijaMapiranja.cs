using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;

namespace SBP2017.Hippocrates.Bolnica.Data.MapiranjaMySql
{
    public class TerapijaMapiranja : ClassMap<Terapija>
    {
        public TerapijaMapiranja()
        {
            Table("TERAPIJA");

            Id(x => x.Id, "ID");

            Map(x => x.Datum_do, "DATUM_DO");
            Map(x => x.Datum_od, "DATUM_OD");
            Map(x => x.Opis, "OPIS");

            References(x => x.TerapijaPacijent).Column("MATBRP").LazyLoad();
            References(x => x.TerapijaDijagnoza).Column("ŠIFRA_DIJAGNOZE").LazyLoad();
            References(x => x.TerapijaLekar).Column("MATBRL").LazyLoad();
        }
    }
}
