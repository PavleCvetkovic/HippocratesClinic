using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class DobavljacMapiranje : ClassMap<Dobavljac>
    {
        public DobavljacMapiranje()
        {
            Table("DOBAVLJAC");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");

            HasManyToMany(x => x.DobavljaMaterijal)
                .Table("DOBAVLJA")
                .ParentKeyColumn("ID_DOBAVLJAC")
                .ChildKeyColumn("ID_MATERIJALA").Cascade.All().Not.LazyLoad();

            HasManyToMany(x => x.DobavljaZaKC)
                .Table("CENTAR_KUPUJE_OD")
                .ParentKeyColumn("ID_DOBAVLJACA")
                .ChildKeyColumn("ID_KC").Cascade.All().Not.LazyLoad();
        }
    }
}
