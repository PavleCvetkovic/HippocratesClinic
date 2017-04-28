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

            CompositeId(x => x.Id)
                .KeyReference(x => x.Pacijent, "ID_PACIJENTA")
                .KeyReference(x => x.Lista, "ID_LISTE_CEKANJA");

            Map(x => x.DatumUpisa, "DATUM_UPISA");
            Map(x => x.OcekivanoVremeCekanja, "OCEKIVANO_VREME");
        }
    }
}
