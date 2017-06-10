using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Model;

namespace SBP2017.Hippocrates.Bolnica.Controller
{
    class GlavnaSestraController : IController
    {
        IModel model;
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

    }
}
