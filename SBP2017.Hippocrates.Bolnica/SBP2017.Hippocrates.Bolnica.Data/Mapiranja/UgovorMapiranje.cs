using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class UgovorMapiranje : ClassMap<Ugovor>
    {
        public UgovorMapiranje()
        {
            Table("UGOVOR");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Pozicija, "POZICIJA");
            Map(x => x.BrojSatiNedeljno, "BROJ_SATI_NEDELJNO");
            Map(x => x.TipIsplate, "TIP_ISPLATE");
            Map(x => x.TipUgovora, "TIP_UGOVORA");
            Map(x => x.Plata, "PLATA");

            References(x => x.KlinickiCentar).Column("ID_KC").LazyLoad();
            HasOne(x => x.Zaposleni).PropertyRef("Ugovor").Cascade.All();
        }
    }
}
