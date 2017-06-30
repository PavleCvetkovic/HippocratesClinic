using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Data_Transfer_Objects
{
    public class DobavljacDto
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }

        public DobavljacDto()
        {

        }
        public DobavljacDto (int id, string ime)
        {
            Id = id;
            Ime = ime;
        }
    }
}
