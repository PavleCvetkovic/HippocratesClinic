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
        public void searchPatientsByJMBG(string jmbg)
        {
            (model as SestraBolnicarModel).searchPatientsByJMBG(jmbg);
        }
       
    }
}
