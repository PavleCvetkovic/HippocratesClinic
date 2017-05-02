using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class CentralniMagacinMapiranje : ClassMap<CentralniMagacin>
    {
        public CentralniMagacinMapiranje()
        {
            Table("CENTRALNI_MAGACIN");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.KlinickiCentar).Column("ID_KC").Unique();

        }
    }
}
