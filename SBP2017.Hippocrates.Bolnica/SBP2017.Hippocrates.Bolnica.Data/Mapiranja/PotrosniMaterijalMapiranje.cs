using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class PotrosniMaterijalMapiranje : ClassMap<PotrosniMaterijal>
    {
        public PotrosniMaterijalMapiranje()
        {
            Table("POTROSNI_MATERIJAL");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");
            Map(x => x.CenaPoJedinici, "CENA_PO_JEDINICI");
            Map(x => x.KriticniNivoZaNarucivanje, "KRITICNI_NIVO_ZA_NARUCIVANJE");
            Map(x => x.TipMaterijala, "TIP_MATERIJALA");
            Map(x => x.NacinUzimanja, "NACIN_UZIMANJA");
            Map(x => x.TipicnaDoza, "TIPICNA_DOZA");
            Map(x => x.NacinAdministracije, "NACIN_ADMINISTRACIJE");

            References(x => x.CentralniMag).Column("ID_CENTRALNOG_MAGACINA").LazyLoad();

            HasMany(x => x.PacijetniUzimajuLek).KeyColumn("ID_LEKA").Cascade.All();

            HasManyToMany(x => x.MagaciniSaMaterijalom)
                .Table("MAGACIN_KLINIKE_SADRZI")
                .ParentKeyColumn("ID_POTROSNG_MATERIJALA")
                .ChildKeyColumn("ID_MAGACINA")
                .Inverse()
                .Cascade.All();           

            HasManyToMany(x => x.MaterijalDobavljaju)
                .Table("DOBAVLJAC")
                .ParentKeyColumn("ID_MATERIJALA")
                .ChildKeyColumn("ID_DOBAVLJACA")
                .Inverse().Cascade.All();

        }
    }
}
