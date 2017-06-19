using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Oracle.ManagedDataAccess.Client;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    public class DirektorModel : GlavnaSestraModel
    {
        private DataTable suppliers;
        private DataTable clinics;
        private DataTable allBeds;
        private DataTable allEmployees;

        #region Properties

        public DataTable Suppliers { get { return this.suppliers; } }
        public DataTable Clinics { get { return this.clinics; } }
        public DataTable AllBeds { get { return this.allBeds; } }
        public DataTable AllEmployees { get { return this.allEmployees; } }        

        #endregion
        public DirektorModel() : base()
        {
            
        }

        public DirektorModel(Zaposleni _user) : base(_user)
        {
            suppliers = new DataTable("Dobavljaci");
            suppliers.Columns.Add("ID");
            suppliers.Columns.Add("Naziv");
            clinics = new DataTable("Klinike");
            clinics.Columns.Add("ID");
            clinics.Columns.Add("Naziv");
            clinics.Columns.Add("Glavna sestra");
            allBeds = new DataTable("Svi kreveti");
            allBeds.Columns.Add("BROJ");
            allBeds.Columns.Add("SLOBODAN");
            allBeds.Columns.Add("KLINIKA");
            allEmployees = new DataTable("Svi zaposleni");
            allEmployees.Columns.Add("ID");
            allEmployees.Columns.Add("Ime");
            allEmployees.Columns.Add("Prezime");
            allEmployees.Columns.Add("Datum rodjenja");
            allEmployees.Columns.Add("Klinika zaposlenog");
            allEmployees.Columns.Add("Tip zaposlenog");
        }

        public bool AddSupplier(int idSupp)
        {
            ISession s = DataLayer.GetSession();
            Dobavljac dob = s.Load<Dobavljac>(idSupp);
            
            dob.DobavljaZaKC.Add(user.Klinika.KlinickiCentar);
            s.SaveOrUpdate(dob);
            s.Flush();
            s.Close();

            refreshData();
            return true;
        }

        public bool DeleteSupplier(int idSupp) //OPASNO NE RADI
        {

            ISession s = DataLayer.GetSession();
            s.CreateSQLQuery("delete from CENTAR_KUPUJE_OD where ID_KC = " + user.Klinika.KlinickiCentar.Id +
                             " and ID_DOBAVLJACA = " + idSupp).ExecuteUpdate();                                                            
            return true;
        }

        public bool addBed(int BedID,int clinicID)
        {
            ISession s = DataLayer.GetSession();
            Krevet k = s.QueryOver<Krevet>().Where(x => x.Id == BedID).SingleOrDefault<Krevet>();
            if (k == null) //ne postoji krevet sa tim ID-jem
            {
                s.Close();
                s.Dispose();
                return false;
            }
            if (k.Klinika.Id == clinicID)
            {
                s.Close();
                s.Dispose();
                return false;//krevet je vec na klinici
            }
            foreach (BoraviNaKlinici bk in k.Klinika.Pacijenti)
            {
                if (bk.BrojKreveta == k.Id)
                {
                    s.Close();
                    s.Dispose();
                    return false; //krevet je zauzet
                }
            }
            Klinika target = s.Load<Klinika>(clinicID);
            k.Klinika = target;
            target.KoristiKrevete.Add(k);
            s.SaveOrUpdate(target);
            s.SaveOrUpdate(k);
            s.Flush();
            s.Close();
            s.Dispose();
            UpdateViews();
            return true;
        }

        public bool FireEmployee(int empId)
        {
            ISession s = DataLayer.GetSession();
            Zaposleni zap = s.Load<Zaposleni>(empId);
            s.Delete(zap);
            s.Flush();
            s.Close();
            return true;
        }

        public override void refreshData()
        {
            base.refreshData();
            suppliers.Rows.Clear();
            clinics.Rows.Clear();
            allEmployees.Rows.Clear();
            allBeds.Rows.Clear();            

            ISession s = DataLayer.GetSession();
            s.Refresh(user);

            //dobavljaci            
            foreach (Dobavljac dobavljac in user.Klinika.KlinickiCentar.Dobavljaci)
            {
                suppliers.Rows.Add(dobavljac.Id, dobavljac.Ime);
            }
            //eksplicitno ucitavanje klinike , kc, i pacijenata
            NHibernateUtil.Initialize(user.Klinika.KlinickiCentar);
            NHibernateUtil.Initialize(user.Klinika.GlavnaSestraKlinike);
            NHibernateUtil.Initialize(user.Klinika.Pacijenti);
            //klinike
            foreach (Klinika k in user.Klinika.KlinickiCentar.Klinike)
            {
                clinics.Rows.Add(k.Id, k.Naziv, k.GlavnaSestraKlinike.Ime + " " + k.GlavnaSestraKlinike.Prezime);
            }
            //svi kreveti
            foreach (Krevet k in user.Klinika.KlinickiCentar.Kreveti)
            {
                bool empty = true;

                PacijentKlinickogCentra pacijent = null;
                foreach (Klinika klinika in user.Klinika.KlinickiCentar.Klinike)
                {
                    foreach (BoraviNaKlinici bk in klinika.Pacijenti)
                    {
                        if (k.Id == bk.BrojKreveta)
                        {
                            empty = false;
                            pacijent = bk.Pacijent;
                        }
                        else
                            empty = true;
                    }
                }
                if (empty)
                    allBeds.Rows.Add(k.Id.ToString(), "DA", k.Klinika.Naziv);
                else
                    allBeds.Rows.Add(k.Id.ToString(), pacijent.JMBG + " " + pacijent.Ime + " " + pacijent.Prezime, k.Klinika.Naziv);
            }
            //svi zaposleni
            IList<Zaposleni> zaposleniLista = s.QueryOver<Zaposleni>()
                .JoinQueryOver(p=>p.Klinika)
                .Where(a=> a.KlinickiCentar == user.Klinika.KlinickiCentar)                
                .List<Zaposleni>();
            foreach (Zaposleni zap in zaposleniLista)
            {
                allEmployees.Rows.Add(zap.Id, zap.Ime, zap.Prezime, zap.DatumRodjenja, zap.Klinika.Naziv, zap.TipZaposlenog);
            }
            s.Close();
        }
    }
}
