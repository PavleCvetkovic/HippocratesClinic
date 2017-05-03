using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class DomZdravljaMapiranje:ClassMap<DomZdravlja>
    {
        public DomZdravljaMapiranje()
        {
            Table("DOM_ZDRAVLJA");

            Id(x => x.MBR).Column("MBR").GeneratedBy.Assigned();

            Map(x => x.Ime).Column("IME");
            Map(x => x.Opstina).Column("OPSTINA");
            Map(x => x.Adresa).Column("ADRESA");
            Map(x => x.Lokacija).Column("LOKACIJA");

            HasMany(x => x.IzabraniLekari).KeyColumn("MBRZU").LazyLoad().Cascade.All().Inverse();
        }
    }
}
