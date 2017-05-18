using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Model;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Controller
{
    class LoginController : IController
    {
        private IModel model;

        public LoginController()
        {

        }
        public LoginController(IModel model)
        {
            this.model = model;
        }
        public void AddModel(IModel model)
        {
            this.model = model;
        }
        public bool CheckLogin(int Id,string Password)
        {
            return ((LoginModel)model).CheckLogin(Id, Password);
        }
        public Zaposleni returnUser()
        {
            return (model as LoginModel).returnUser();
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
