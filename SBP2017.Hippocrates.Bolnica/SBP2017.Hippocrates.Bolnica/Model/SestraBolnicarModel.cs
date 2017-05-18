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
        
        public SestraBolnicarModel(Zaposleni user)
        {
            views = new List<IView>();
            ISession s = DataLayer.GetSession();
            this.user = user;
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
        public void refreshData()
        {
            ISession s = DataLayer.GetSession();
            s.Refresh(user);
            s.Close();
        }
        public void AddPatientToQueue(PacijentKlinickogCentra patient,int ExpectedTime)
        {
            ISession s = DataLayer.GetSession();
            PacijentiCekaju pc = new PacijentiCekaju()
            {
                DatumUpisa = DateTime.Now,
                ListaCekanja = user.Klinika.ListaCekanja,
                OcekivanoVremeCekanja = ExpectedTime,
                Pacijent = patient
            };
            user.Klinika.ListaCekanja.Pacijenti.Add(pc);
            s.SaveOrUpdate(user.Klinika);
            s.Flush();
            s.Close();
        }
        public IList<BoraviNaKlinici> patientsAtClinic()
        {
            ISession s = DataLayer.GetSession();
            IList<BoraviNaKlinici> Patients = user.Klinika.Pacijenti.ToList<BoraviNaKlinici>();
            s.Close();
            return Patients;
        }
        public IList<PacijentiCekaju> patientsAtQueue()
        {
            ISession s = DataLayer.GetSession();
            IList<PacijentiCekaju> Patients = user.Klinika.ListaCekanja.Pacijenti.ToList<PacijentiCekaju>();
            s.Close();
            return Patients;
        }
        public int vacantBeds()
        {
            ISession s = DataLayer.GetSession();
            int sum = user.Klinika.KoristiKrevete.Count;
            int used = s.QueryOver<BoraviNaKlinici>().Where(x => x.Klinika == user.Klinika).RowCount();
            sum -= used;
            s.Close();
            return sum;
        }

    }
}
