﻿using System;
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

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();
            Map(x => x.DatumPrijema, "DATUM_PRIJEMA");
            Map(x => x.OcekivaniBoravak, "OCEKIVANI_BORAVAK");
            Map(x => x.DatumOtpusta, "DATUM_OTPUSTA");
            Map(x => x.BrojKreveta, "BROJ_KREVETA");

            References(x => x.Klinika).Column("ID_KLINIKE").LazyLoad();
            References(x => x.Pacijent).Column("ID_PACIJENTA").LazyLoad();
            
        }
    }
}
