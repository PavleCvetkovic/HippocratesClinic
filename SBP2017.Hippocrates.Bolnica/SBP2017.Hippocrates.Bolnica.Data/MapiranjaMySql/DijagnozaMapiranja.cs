using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
namespace SBP2017.Hippocrates.Bolnica.Data.MapiranjaMySql
{
    public class DijagnozaMapiranja : ClassMap<Dijagnoza>
    {
        public DijagnozaMapiranja()
        {
            Table("DIJAGNOZA");

            Id(x => x.Sifra, "ŠIFRA");

            Map(x => x.Ime, "IME");
            HasMany(x => x.Dijagnostifikovano).KeyColumn("ŠIFRA_DIJAGNOZE").LazyLoad();

        }
    }
}
