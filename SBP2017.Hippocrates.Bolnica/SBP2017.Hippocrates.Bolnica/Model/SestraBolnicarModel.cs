using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.View;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
using NHibernate;


namespace SBP2017.Hippocrates.Bolnica.Model
{
    class SestraBolnicarModel : IModel
    {
        List<IView> views;

        int vacantbeds;
        Zaposleni user;
        Pacijent patient;//search patient (MySQL)

        private SestraBolnicarModel()
        {

        }
        public SestraBolnicarModel(Zaposleni user)
            :this()
        {
            views = new List<IView>();
            this.user = user;
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
        public int VacantBeds
        {
            get
            {
                return vacantbeds;
            }
        }
       
        public void vacantBeds()
        {
            int sum = user.Klinika.KoristiKrevete.Count;
            int used = user.Klinika.Pacijenti.Where(x => x.DatumOtpusta == null).Count();
            sum -= used;
            vacantbeds = sum;
        }
        public void searchPatientsByJMBG(string jmbg)
        {
        }

        public void refreshData()
        {
            throw new NotImplementedException();
        }
    }
}
