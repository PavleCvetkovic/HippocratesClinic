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
using System.Data;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    class SestraBolnicarModel : IModel
    {
        List<IView> views;

        int vacantbeds;
        Zaposleni user;

        Pacijent patient;//search patient (MySQL)
        DataTable clinicPatients;
        DataTable clinicQueue;
        

        private SestraBolnicarModel()
        {
            clinicPatients = new DataTable("Pacijenti na klinici");
            clinicQueue = new DataTable("Pacijenti na listi cekanja");
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
        public DataTable ClinicPatients
        {
            get
            {
                return clinicPatients;
            }
        }
        public DataTable ClinicQueue
        {
            get
            {
                return clinicQueue;
            }
        }
 
        public void searchPatientsByJMBG(string jmbg)
        {
        }

        public void refreshData()
        {
            ISession s = DataLayer.GetSession();
            s.Refresh(user);
            //tabela za trenutne pacijente na klinici
            clinicPatients.Rows.Clear();
            clinicPatients.Columns.Clear();
            clinicPatients.Columns.Add("JMBG");
            clinicPatients.Columns.Add("IME");
            clinicPatients.Columns.Add("PREZIME");
            clinicPatients.Columns.Add("BROJ KREVETA");
            clinicPatients.Columns.Add("DATUM PRIJEMA");
            clinicPatients.Columns.Add("OCEKIVANI BORAVAK");

            foreach (BoraviNaKlinici b in user.Klinika.Pacijenti)
            {
                clinicPatients.Rows.Add(b.Pacijent.JMBG, b.Pacijent.Ime, b.Pacijent.Prezime, b.BrojKreveta, b.DatumPrijema, b.OcekivaniBoravak);
            }
            //slobodan broj kreveta
            int sum = user.Klinika.KoristiKrevete.Count;
            int used = user.Klinika.Pacijenti.Where(x => x.DatumOtpusta == null).Count();
            sum -= used;
            vacantbeds = sum;
            //tabela za listu cekanja
            clinicQueue.Rows.Clear();
            clinicQueue.Columns.Clear();
            clinicQueue.Columns.Add("JMBG");
            clinicQueue.Columns.Add("IME");
            clinicQueue.Columns.Add("PREZIME");
            clinicQueue.Columns.Add("DATUM UPISA");
            foreach(PacijentiCekaju p in user.Klinika.ListaCekanja.Pacijenti)
            {
                clinicQueue.Rows.Add(p.Pacijent.JMBG, p.Pacijent.Ime, p.Pacijent.Prezime, p.DatumUpisa);
            }
            //eksplicitno ucitavanje klinike , kc i glavne sestre
            NHibernateUtil.Initialize(user.Klinika.KlinickiCentar);
            NHibernateUtil.Initialize(user.Klinika.GlavnaSestraKlinike);
            //

            s.Close();
        }
    }
}
