using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.View;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    public interface IModel
    {
        void AddView(IView view);
        void UpdateViews();
        void refreshData();
        bool searchPatientsByJMBG(string jmbg);
        bool searchPatientsByLBO(string lbo);
        bool searchPatientsByBedNo(string No);
    }
}
