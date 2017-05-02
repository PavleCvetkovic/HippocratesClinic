using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBP2017.Hippocrates.Bolnica.Data.Entiteti
{
    public class ListaCekanja
    {
        public virtual int Id { get; protected set; }
        public virtual Klinika Klinika { get; set; }

        public virtual IList<PacijentiCekaju> Pacijenti { get; set; }

        public ListaCekanja()
        {
            Pacijenti = new List<PacijentiCekaju>();
        }
    }
}
