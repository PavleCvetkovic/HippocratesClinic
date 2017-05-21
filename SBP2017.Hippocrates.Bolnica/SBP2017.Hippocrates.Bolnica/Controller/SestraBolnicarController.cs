using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Model;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;

namespace SBP2017.Hippocrates.Bolnica.Controller
{
    class SestraBolnicarController : IController
    {
        private IModel model;
        public void AddModel(IModel model)
        {
            this.model = model;
        }

        public IModel getModel()
        {
            return model;
        }
        public void refreshData()
        {
            model.refreshData();
        }
        public bool searchPatientsByJMBG(string jmbg)
        {
            return (model as SestraBolnicarModel).searchPatientsByJMBG(jmbg);
        }
        public bool searchPatientsByLBO(string lbo)
        {
            return (model as SestraBolnicarModel).searchPatientsByLBO(lbo);
        }
        public bool searchPatientsByBedNo(string No)
        {
            return (model as SestraBolnicarModel).searchPatientsByBedNo(No);
        }
       
    }
}
