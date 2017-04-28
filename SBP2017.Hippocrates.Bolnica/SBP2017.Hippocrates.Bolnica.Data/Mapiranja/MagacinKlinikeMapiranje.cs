using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class MagacinKlinikeMapiranje : ClassMap<MagacinKlinike>
    {
        public MagacinKlinikeMapiranje()
        {
            Table("MAGACIN_KLINIKE");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.MagacinNaKlinici).Column("ID_KLINIKE").LazyLoad();

            HasManyToMany(x => x.MaterijalUMagacinu)
                .Table("MAGACIN_KLINIKE_SADRZI")
                .ParentKeyColumn("ID_MAGACINA")
                .ChildKeyColumn("ID_POTROSNOG_MATERIJALA");
        }
    }
}
