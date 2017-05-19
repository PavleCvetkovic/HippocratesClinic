using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class NarudzbenicaMapiranje : ClassMap<Narudzbenica>
    {
        public NarudzbenicaMapiranje()
        {
            Table("NARUDZBENICA");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");
            Map(x => x.ImeKlinike, "IME_KLINIKE");
            Map(x => x.DatumNarudzbine, "DATUM");
            Map(x => x.DatumIsporuke, "DATUM_ISPORUKE");
            Map(x => x.ImeZaposlenog, "IME_ZAPOSLENOG");
            Map(x => x.Cena, "CENA");

            References(x => x.Klinika).Column("ID_KLINIKE").LazyLoad();

            References(x => x.NaruceniMaterijal).Column("ID_POTROSNOG_MATERIJALA").LazyLoad();

        }
    }
}
