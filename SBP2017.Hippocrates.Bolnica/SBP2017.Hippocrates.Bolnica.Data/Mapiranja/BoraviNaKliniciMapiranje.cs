using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using FluentNHibernate.Mapping;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class BoraviNaKliniciMapiranje : ClassMap<BoraviNaKlinici>
    {
        public BoraviNaKliniciMapiranje()
        {
            Table("BORAVI_NA_KLINICI");

            Id(x => x.Id).Column("ID");
            Map(x => x.DatumPrijema, "DATUM_PRIJEMA");
            Map(x => x.OcekivaniBoravak, "DATUM_OTPUSTA");
            Map(x => x.DatumOtpusta, "DATUM_OTPUSTA");
            References(x => x.Klinika).Column("ID_KLINIKE");
            References(x => x.Pacijent).Column("ID_PACIJENTA");
            References(x => x.KrevetPacijenta).Column("BROJ_KREVETA").LazyLoad();
        }
    }
}
