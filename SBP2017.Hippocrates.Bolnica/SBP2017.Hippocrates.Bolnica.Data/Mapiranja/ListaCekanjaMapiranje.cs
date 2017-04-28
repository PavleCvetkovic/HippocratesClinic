using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class ListaCekanjaMapiranje : ClassMap<ListaCekanja>
    {
        public ListaCekanjaMapiranje()
        {
            Table("LISTA_CEKANJA");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            HasMany(x => x.PacijentiKojiCekaju).KeyColumn("ID_PACIJENTA").Cascade.All().Inverse();
        }
    }
}
