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
    public class BoraviNaKliniciMapranje : ClassMap<BoraviNaKlinici>
    {
        public BoraviNaKliniciMapranje()
        {
            Table("BORAVI_NA_KLINICI");

            CompositeId(x => x.Id)
                .KeyReference(x => x.KlnikaPacijenta, "ID_KLINIKE")
                .KeyReference(x => x.Pacijent, "ID_PACIJENTA");

            Map(x => x.DatumPrijema, "DATUM_PRIJEMA");
            Map(x => x.OcekivaniBoravak, "DATUM_OTPUSTA");
            Map(x => x.DatumOtpusta, "DATUM_OTPUSTA");

            References(x => x.KrevetPacijenta).Column("BROJ_KREVETA").LazyLoad();
        }
    }
}
