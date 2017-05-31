using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class MagacinKlinikeSadrziMapiranje:ClassMap<MagacinKlinikeSadrzi>
    {
        public MagacinKlinikeSadrziMapiranje()
        {
            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Kolicina).Column("KOLICINA");

            References(x => x.MagacinKlinike).Column("ID_MAGACINA");
            References(x => x.PotrosniMaterijal).Column("ID_POTROSNOG_MATERIJALA");
        }
    }
}
