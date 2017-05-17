using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.View;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data;
using NHibernate;


namespace SBP2017.Hippocrates.Bolnica.Model
{
    class SestraBolnicarModel : IModel
    {
        List<IView> views;

        Zaposleni user;
        PacijentKlinickogCentra Patient;
        Klinika Clinic;
        KlinickiCentar Center;
        
        public SestraBolnicarModel(Zaposleni user)
        {
            views = new List<IView>();
            this.user = user;
            Clinic = user.Klinika;
            Center = Clinic.KlinickiCentar;
            Patient = null;
        }
        public void AddView(IView view)
        {
            views.Add(view);
        }

        public void UpdateViews()
        {
            foreach (IView v in views)
                v.Update();
        }
        public PacijentKlinickogCentra getPatient()
        {
            return Patient;
        }
        public PacijentKlinickogCentra searchPatientsByJMBG(string JMBG) //returns Patient with given JMBG
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from PacijentKlinickogCentra as p where p.JMBG = '" + JMBG + "'");
            PacijentKlinickogCentra p = q.UniqueResult<PacijentKlinickogCentra>();
            Patient = p;
            s.Close();
            return p;
        }
        public void AddPatientToQueue(PacijentKlinickogCentra patient,int ExpectedTime)
        {
            ISession s = DataLayer.GetSession();
            PacijentiCekaju pc = new PacijentiCekaju()
            {
                DatumUpisa = DateTime.Now,
                ListaCekanja = Clinic.ListaCekanja,
                OcekivanoVremeCekanja = ExpectedTime,
                Pacijent = patient
            };
            Clinic.ListaCekanja.Pacijenti.Add(pc);
            s.SaveOrUpdate(Clinic);
            s.Flush();
            s.Close();
        }

    }
}
