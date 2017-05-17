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
        PacijentKlinickogCentra patient;
        Klinika clinic;
        KlinickiCentar center;
        
        public SestraBolnicarModel(Zaposleni user)
        {
            views = new List<IView>();
            ISession s = DataLayer.GetSession();
            this.user = user;
            s.Refresh(user);
            clinic = user.Klinika;
            center = clinic.KlinickiCentar;
            patient = null;
            s.Close();
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
        public Zaposleni User
        {
            get
            {
                return user;
            }
        }
        public PacijentKlinickogCentra Patient
        {
            get { return patient; }
        }
        public Klinika Klinika
        {
            get
            {
                return clinic;
            }
        }
        public KlinickiCentar ClinicCenter
        {
            get
            {
                return center;
            }
        }
        public PacijentKlinickogCentra getPatient()
        {
            return patient;
        }
        public PacijentKlinickogCentra searchPatientsByJMBG(string JMBG)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from PacijentKlinickogCentra as p where p.JMBG = '" + JMBG + "'");
            PacijentKlinickogCentra p = q.UniqueResult<PacijentKlinickogCentra>();
            patient = p;
            s.Close();
            return p;
        }
        public void AddPatientToQueue(PacijentKlinickogCentra patient,int ExpectedTime)
        {
            ISession s = DataLayer.GetSession();
            PacijentiCekaju pc = new PacijentiCekaju()
            {
                DatumUpisa = DateTime.Now,
                ListaCekanja = clinic.ListaCekanja,
                OcekivanoVremeCekanja = ExpectedTime,
                Pacijent = patient
            };
            clinic.ListaCekanja.Pacijenti.Add(pc);
            s.SaveOrUpdate(clinic);
            s.Flush();
            s.Close();
        }
        public IList<BoraviNaKlinici> patientsAtClinic()
        {
            ISession s = DataLayer.GetSession();
            s.Refresh(clinic);
            IList<BoraviNaKlinici> Patients = clinic.Pacijenti.ToList<BoraviNaKlinici>();
            s.Close();
            return Patients;
        }

    }
}
