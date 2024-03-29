﻿using System;
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

        public void CloseSession()
        {
            throw new NotImplementedException();
        }

        public bool searchPatientsByJMBG(string jmbg)
        {
            throw new NotImplementedException();
        }

        public bool searchPatientsByLBO(string lbo)
        {
            throw new NotImplementedException();
        }

        public bool searchPatientsByBedNo(string No)
        {
            throw new NotImplementedException();
        }
    }
}
