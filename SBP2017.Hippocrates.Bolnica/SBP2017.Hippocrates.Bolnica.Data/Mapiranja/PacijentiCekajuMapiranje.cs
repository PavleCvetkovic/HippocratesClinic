using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class PacijentiCekajuMapiranje : ClassMap<PacijentiCekaju>
    {
        public PacijentiCekajuMapiranje()
        {
            Table("PACIJENTI_CEKAJU");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();
            
            Map(x => x.DatumUpisa, "DATUM_UPISA");
            Map(x => x.OcekivanoVremeCekanja, "OCEKIVANO_CEKANJE");

            References(x => x.ListaCekanja).Column("ID_LISTE_CEKANJA").LazyLoad();
            References(x => x.Pacijent).Column("ID_PACIJENTA").LazyLoad();
        }
    }
}
