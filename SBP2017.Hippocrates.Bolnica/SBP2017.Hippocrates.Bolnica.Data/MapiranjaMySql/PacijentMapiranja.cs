using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
namespace SBP2017.Hippocrates.Bolnica.Data.MapiranjaMySql
{
    public class PacijentMapiranja : ClassMap<Pacijent>
    {
        public PacijentMapiranja()
        {
            Table("PACIJENT");

            Id(x => x.Jmbg, "JMBG").GeneratedBy.Assigned();

            Map(x => x.Ime, "IME");
            Map(x => x.Srednje_slovo, "SREDNJE_SLOVO");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Opstina, "OPŠTINA");
            Map(x => x.Lbo, "LBO");
            Map(x => x.Telefon, "KONTAKT_TELEFON");
            Map(x => x.Email, "EMAIL");
            Map(x => x.Datum_rodjenja, "DATUM_ROĐENJA");
            Map(x => x.Vazi_do, "VAŽI_DO");

            References(x => x.Lekar).Column("MATBRL").LazyLoad();
            HasMany(x => x.PrimioVakcinuVakcine).KeyColumn("JMBGP").Cascade.All().Inverse().LazyLoad();
            HasMany(x => x.DijagnostifikovanoDijagnoze).KeyColumn("MATBRP").Cascade.All().Inverse().LazyLoad();
            HasMany(x => x.Terapije).KeyColumn("MATBRP").Cascade.All().Inverse().LazyLoad();
        }
    }
}
