using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
namespace SBP2017.Hippocrates.Bolnica.Data.MapiranjaMySql
{
    public class DomZdravljaMapiranja : ClassMap<DomZdravlja>
    {
        public DomZdravljaMapiranja()
        {
            Table("DOM_ZDRAVLJA");

            Id(x => x.Mbr, "MBR").GeneratedBy.Assigned();

            Map(x => x.Ime, "IME");
            Map(x => x.Opstina, "OPŠTINA");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Adresa, "ADRESA");

            HasMany(x => x.Lekari).KeyColumn("MBRZU").LazyLoad().Cascade.All().Inverse();
        }
    }
}
