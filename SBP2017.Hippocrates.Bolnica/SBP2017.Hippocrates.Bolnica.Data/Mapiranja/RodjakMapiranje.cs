using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class RodjakMapiranje : ClassMap<Rodjak>
    {
        public RodjakMapiranje()
        {
            Table("RODJAK");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Srodstvo, "SRODSTVO");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Telefon, "TELEFON");

            HasMany(x => x.PacijentiUSrodstvu).KeyColumn("ID_RODJAKA").Inverse().Cascade.All().LazyLoad();
        }
    }
}
