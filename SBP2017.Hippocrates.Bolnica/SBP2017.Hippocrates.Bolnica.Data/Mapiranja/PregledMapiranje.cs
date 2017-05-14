using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class PregledMapiranje : ClassMap<Pregled>
    {
        public PregledMapiranje()
        {
            Table("PREGLED");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Datum, "DATUM");
            Map(x => x.Vreme, "VREME");
            Map(x => x.Prostorija, "PROSTORIJA");

            References(x => x.Specijalista).Column("ID_SPECIJALISTE");
            References(x => x.Pacijent).Column("ID_PACIJENTA");

        }
    }
}
