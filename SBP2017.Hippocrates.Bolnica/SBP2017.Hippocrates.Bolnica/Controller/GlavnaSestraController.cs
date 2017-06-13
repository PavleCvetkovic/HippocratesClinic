using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.Model;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

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

        public bool searchPatientsByBedNo(string No)
        {
            return model.searchPatientsByBedNo(No);
        }

        public bool searchPatientsByJMBG(string jmbg)
        {
            return model.searchPatientsByJMBG(jmbg);
        }

        public bool searchPatientsByLBO(string lbo)
        {
            return model.searchPatientsByLBO(lbo);
        }
        public void dischargePatient(string Jmbg)
        {
            (model as GlavnaSestraModel).dischargePatient(Jmbg);
        }
        public bool addToQueue(string Jmbg, Rodjak r, string bracnistatus, string pol, string adresa)
        {
            return (model as GlavnaSestraModel).addToQueue(Jmbg, r, bracnistatus, pol, adresa);
        }
        public bool acceptPatient(string Jmbg, Rodjak r, string bracnistatus, string pol, string adresa, int brojkreveta, int boravak)
        {
            return (model as GlavnaSestraModel).acceptPatient(Jmbg, r, bracnistatus, pol, adresa, brojkreveta, boravak);
        }
        public bool AddShift(int EId,DateTime start,DateTime end,string ShiftType)
        {
            return (model as GlavnaSestraModel).addShift(EId, start, end, ShiftType);
        }
        public bool DeleteShift(string ShiftId)
        {
            return (model as GlavnaSestraModel).deleteShift(ShiftId);
        }
        public bool AcceptFromQueue(string Jmbg, int brojkreveta, int boravak)
        {
            return (model as GlavnaSestraModel).acceptFromQueue(Jmbg, brojkreveta, boravak);
        }
    }
}
