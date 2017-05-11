using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class ZaposleniMapiranje : ClassMap<Zaposleni>
    {
        public ZaposleniMapiranje()
        {
            Table("ZAPOSLENI");

            DiscriminateSubClassesOnColumn("TIP_ZAPOSLENOG");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Telefon, "TELEFON");
            Map(x => x.Pol, "POL");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.JMBG, "JMBG");
            Map(x => x.Password, "PASSWORD");

            References(x => x.Ugovor).Column("ID_UGOVORA").LazyLoad();
            References(x => x.Klinika, "ID_KLINIKE").LazyLoad();
            

            HasMany(x => x.Iskustva).KeyColumn("ID_ZAPOSLENOG").Inverse().Cascade.All();
            HasMany(x => x.Kvalifikacije).KeyColumn("ID_ZAPOSLENOG").Inverse().Cascade.All();
            HasMany(x => x.Smene).KeyColumn("ID_ZAPOSLENOG").Inverse().Cascade.All();
        }
    }
    public class SpecijalistaMapiranje : SubclassMap<Specijalista>
    {
        public SpecijalistaMapiranje()
        {
            DiscriminatorValue("SPECIJALISTA");
            Map(x => x.BrojOrdinacije).Column("BROJ_ORDINACIJE");
        }
    }
    public class SestraMapiranje : SubclassMap<Sestra>
    {
        public SestraMapiranje()
        {
            DiscriminatorValue("SESTRA");
            // moze da se uprosti i na klase mladja,starija,glavna sestra, ali ne vidim svrhu, zbog toga ovako mapiram.
            Map(x => x.TipSestre).Column("TIP_SESTRE");
        }
    }
    public class PomocnoOsobljeMapiranje : SubclassMap<PomocnoOsoblje>
    {
        public PomocnoOsobljeMapiranje()
        {
            DiscriminatorValue("POMOCNOOSBLJE");
        }
    }
    public class BolnicarMapiranje : SubclassMap<Bolnicar>
    {
        public BolnicarMapiranje()
        {
            DiscriminatorValue("BOLNICAR");
        }
    }
}
