using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Data.Mapiranja
{
    public class IzabraniLekarMapiranje:ClassMap<IzabraniLekar>
    {
        public IzabraniLekarMapiranje()
        {
            Table("IZABRANI_LEKAR");

            Id(x => x.JMBG).Column("JMBG").GeneratedBy.Assigned();

            Map(x => x.Ime).Column("IME");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.DatumRodjenja).Column("DATUM_RODJENJA");
            Map(x => x.Adresa).Column("ADRESA");

            References(x => x.DomZdravlja).Column("MBRZU");
        }
    }
}
