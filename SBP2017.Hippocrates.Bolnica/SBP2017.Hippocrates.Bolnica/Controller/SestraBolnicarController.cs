using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Model;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

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
        public IList<BoraviNaKlinici> patientsAtClinic()
        {
            return (model as SestraBolnicarModel).patientsAtClinic();
        }
        public IList<PacijentiCekaju> patientsAtQueue()
        {
            return (model as SestraBolnicarModel).patientsAtQueue();
        }
        public int vacantBeds()
        {
            return (model as SestraBolnicarModel).vacantBeds();
        }
        public void refreshData()
        {
            model.refreshData();
        }
    }
}
