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
    public class SestraBolnicarController : IController
    {
        protected IModel model;
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
        public void dischargePatient(string jmbg)
        {
            (model as SestraBolnicarModel).dischargePatient(jmbg);
        }
        public bool acceptPatient(string Jmbg, Rodjak r, string bracnistatus, string pol, string adresa, int brojkreveta,int boravak)
        {
            return (model as SestraBolnicarModel).acceptPatient(Jmbg, r, bracnistatus, pol, adresa,brojkreveta,boravak);
        }
        public bool acceptFromQueue(string Jmbg,int brojkreveta,int boravak)
        {
            return (model as SestraBolnicarModel).acceptFromQueue(Jmbg, brojkreveta, boravak);
        }
        public bool addToQueue(string Jmbg, Rodjak r, string bracnistatus, string pol, string adresa)
        {
            return (model as SestraBolnicarModel).addToQueue(Jmbg, r, bracnistatus, pol, adresa);
        }


    }
}
