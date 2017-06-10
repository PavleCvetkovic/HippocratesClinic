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
    public class SestraBolnicarModel : IModel
    {
        protected List<IView> views;

        protected int vacantbeds;
        protected Zaposleni user;
        

        protected Pacijent patient;//search patient (MySQL)
        protected PacijentKlinickogCentra clinicPatient;
        protected DataTable clinicPatients;
        protected DataTable clinicQueue;
        protected DataTable patientVaccines;
        protected DataTable patientTherapies;
        protected DataTable patientDiagnosis;
        protected DataTable patientClinics;
        protected DataTable patientMedicines;
        

        public SestraBolnicarModel()
        {
            clinicPatients = new DataTable("Pacijenti na klinici");
            clinicQueue = new DataTable("Pacijenti na listi cekanja");
            patientVaccines = new DataTable("Vakcine pacijenta");
            patientTherapies = new DataTable("Terapije pacijenta");
            patientDiagnosis = new DataTable("Dijagnoze pacijenta");
            patientClinics = new DataTable("Klinike pacijenta");
            patientMedicines = new DataTable("Lekovi pacijenta");
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
        public DataTable PatientDiagnosis
        {
            get
            {
                return patientDiagnosis;
            }
        }
        public DataTable PatientTherapies
        {
            get
            {
                return patientTherapies;
            }
        }
        public DataTable PatientClinics
        {
            get
            {
                return patientClinics;
            }
        }
        public DataTable PatientsVaccines
        {
            get
            {
                return patientVaccines;
            }
        }
        public Pacijent Patient
        {
            get
            {
                return patient;
            }
        }
        public PacijentKlinickogCentra ClinicPatient
        {
            get
            {
                return clinicPatient;
            }
        }
        public DataTable PatientMedicines
        {
            get
            {
                return patientMedicines;
            }
        }
 
        public bool searchPatientsByJMBG(string jmbg)
        {
            ISession ss = DataLayerMySQL.GetSession();
            Pacijent pac = ss.QueryOver<Pacijent>().Where(x => x.Jmbg == jmbg).SingleOrDefault<Pacijent>();
            if (pac != null)
                patient = pac;
            else
                return false;
            //proveri da li postoji u sistemu za klinicke centre
            ISession s = DataLayer.GetSession();
            PacijentKlinickogCentra pkc= s.QueryOver<PacijentKlinickogCentra>()
                .Where(x => x.JMBG == patient.Jmbg)
                .SingleOrDefault<PacijentKlinickogCentra>();
            clinicPatient = pkc;

            s.Close();s.Dispose();
            ss.Close();ss.Dispose();
            UpdateViews();
            return true;
        }
        public bool searchPatientsByLBO(string lbo)
        {
            ISession ss = DataLayerMySQL.GetSession();
            Pacijent pac = ss.QueryOver<Pacijent>().Where(x => x.Lbo == lbo).SingleOrDefault<Pacijent>();
            if (pac != null)
                patient = pac;
            else
                return false;
            ss.Close();ss.Dispose();
            ISession s = DataLayer.GetSession();
            PacijentKlinickogCentra pkc = s.QueryOver<PacijentKlinickogCentra>().Where(x => x.JMBG == patient.Jmbg).SingleOrDefault<PacijentKlinickogCentra>();
            clinicPatient = pkc;
            s.Close();s.Dispose();
            UpdateViews();
            return true;
        }
        public bool searchPatientsByBedNo(string number)
        {
            ISession s = DataLayer.GetSession();
            s.Refresh(user);
            BoraviNaKlinici bk = s.QueryOver<BoraviNaKlinici>()
                .Where(x => x.BrojKreveta == Int32.Parse(number))
                .Where(x => x.DatumOtpusta == null)
                .JoinQueryOver(x=>x.Klinika).Where(x => x.Naziv == user.Klinika.Naziv)
                .SingleOrDefault<BoraviNaKlinici>();
            if (bk != null)
            {
                PacijentKlinickogCentra pkc =
                    s.QueryOver<PacijentKlinickogCentra>().Where(x => x.Id == bk.Pacijent.Id).SingleOrDefault<PacijentKlinickogCentra>();
                clinicPatient = pkc;
                ISession ss = DataLayerMySQL.GetSession();
                patient = ss.QueryOver<Pacijent>().Where(x => x.Jmbg == pkc.JMBG).SingleOrDefault<Pacijent>();
                ss.Close();ss.Dispose();
            }
            else
            {
                s.Close(); s.Dispose();
                return false;
            }
            s.Close();s.Dispose();
            UpdateViews();
            return true;
        }
        public void dischargePatient(string Jmbg)
        {
            ISession s = DataLayer.GetSession();
            BoraviNaKlinici bk = s.QueryOver<BoraviNaKlinici>().Where(x => x.DatumOtpusta == null).Where(x=>x.Klinika==user.Klinika).JoinQueryOver(x => x.Pacijent).Where(x => x.JMBG == Jmbg).SingleOrDefault<BoraviNaKlinici>();
            bk.DatumOtpusta = DateTime.Now;
            s.SaveOrUpdate(bk);
            s.Flush();
            s.Close();s.Dispose();
            UpdateViews();
        }
        
        public bool acceptPatient(string Jmbg,Rodjak r,string bracnistatus,string pol,string adresa,int brojkreveta,int boravak)
        {
            refreshData();
            if (vacantbeds <= 0)
                return false;        //nema mesta
            ISession s = DataLayer.GetSession();
            ISession ss = DataLayerMySQL.GetSession();
            foreach(BoraviNaKlinici bkl in user.Klinika.Pacijenti)
            {
                if (bkl.DatumOtpusta == null && bkl.Pacijent.JMBG == Jmbg)
                    return false; //vec je na klinici
            }
            PacijentKlinickogCentra pkc = s.QueryOver<PacijentKlinickogCentra>().Where(x => x.JMBG == Jmbg).SingleOrDefault<PacijentKlinickogCentra>();
            if (pkc == null)//nema ga u bazi za kc, znaci da treba da se doda
            {
                Pacijent pac = ss.QueryOver<Pacijent>().Where(x => x.Jmbg == Jmbg).SingleOrDefault<Pacijent>();
                pkc = new PacijentKlinickogCentra
                {
                    Ime = pac.Ime,
                    DatumRodjenja = pac.Datum_rodjenja,
                    JMBG = pac.Jmbg,
                    Prezime = pac.Prezime,
                    Adresa = adresa,
                    Pol = pol,
                    BracniStatus = bracnistatus
                };
                Rodjak rodj = new Rodjak()
                {
                    Ime = r.Ime,
                    Prezime = r.Prezime,
                    Adresa = r.Adresa,
                    Srodstvo = r.Srodstvo,
                    Telefon = r.Telefon,
                };
                s.Save(pkc);
                rodj.PacijentiUSrodstvu.Add(pkc);
                pkc.Rodjak = rodj;
                s.SaveOrUpdate(rodj);
                s.Flush();
            }
            BoraviNaKlinici bk = new BoraviNaKlinici
            {
                BrojKreveta = brojkreveta,
                DatumPrijema = DateTime.Now,
                DatumOtpusta = null,
                Klinika = user.Klinika,
                OcekivaniBoravak = boravak,
                Pacijent = pkc
            };
            pkc.Klinike.Add(bk);

            s.SaveOrUpdate(pkc);
            s.Flush();
            s.Close();s.Dispose();
            ss.Close();ss.Dispose();
            clinicPatient = pkc;
            UpdateViews();

            return true;
        }
        public bool acceptFromQueue(string Jmbg,int brojkreveta,int boravak) //nije testirana
        {
            refreshData();
            if (vacantbeds <= 0)
                return false;
            ISession s = DataLayer.GetSession();
            PacijentKlinickogCentra pkc = s.QueryOver<PacijentKlinickogCentra>().Where(x => x.JMBG == Jmbg).SingleOrDefault<PacijentKlinickogCentra>();
            //izbrisi sa liste cekanja
            IList<PacijentiCekaju> lista = pkc.ListeCekanja;
            foreach(PacijentiCekaju pcek in lista)
            {
                if (pcek.ListaCekanja.Klinika.Id == user.Klinika.Id)
                {
                    pkc.ListeCekanja.Remove(pcek);
                    user.Klinika.ListaCekanja.Pacijenti.Remove(pcek);
                    s.Delete(pcek);
                    s.Flush();
                    break;
                }
            }

            BoraviNaKlinici bk = new BoraviNaKlinici
            {
                BrojKreveta = brojkreveta,
                DatumPrijema = DateTime.Now,
                DatumOtpusta = null,
                Klinika = user.Klinika,
                OcekivaniBoravak = boravak,
                Pacijent = pkc
            };
            pkc.Klinike.Add(bk);
            s.SaveOrUpdate(pkc);
            s.Flush();
            s.Close();s.Dispose();
            UpdateViews();
            return true;
        }

        public bool addToQueue(string Jmbg, Rodjak r, string bracnistatus, string pol, string adresa)
        {
            ISession s = DataLayer.GetSession();
            s.Refresh(user);
            ISession ss = DataLayerMySQL.GetSession();
            foreach (PacijentiCekaju pac in user.Klinika.ListaCekanja.Pacijenti)
            {
                if (pac.Pacijent.JMBG == Jmbg)
                    return false; //ima ga vec na listi cekanja
            }
            PacijentKlinickogCentra pkc = s.QueryOver<PacijentKlinickogCentra>().Where(x => x.JMBG == Jmbg).SingleOrDefault<PacijentKlinickogCentra>();
            if (pkc == null)//nema ga u bazi za kc, znaci da treba da se doda
            {
                Pacijent pac = ss.QueryOver<Pacijent>().Where(x => x.Jmbg == Jmbg).SingleOrDefault<Pacijent>();
                pkc = new PacijentKlinickogCentra
                {
                    Ime = pac.Ime,
                    DatumRodjenja = pac.Datum_rodjenja,
                    JMBG = pac.Jmbg,
                    Prezime = pac.Prezime,
                    Adresa = adresa,
                    Pol = pol,
                    BracniStatus = bracnistatus
                };
                s.Save(pkc);
                s.Flush();
                Rodjak rodj = new Rodjak()
                {
                    Ime = r.Ime,
                    Prezime = r.Prezime,
                    Adresa = r.Adresa,
                    Srodstvo = r.Srodstvo,
                    Telefon = r.Telefon,
                };
                pkc.Rodjak = rodj;
                rodj.PacijentiUSrodstvu.Add(pkc);
                s.SaveOrUpdate(rodj);
                s.Flush();
            }
            PacijentiCekaju pc = new PacijentiCekaju()
            {
                ListaCekanja = user.Klinika.ListaCekanja,
                DatumUpisa = DateTime.Now,
                OcekivanoVremeCekanja = user.Klinika.ListaCekanja.Pacijenti.Count * 2,
                Pacijent = pkc
            };
            s.Save(pc);
            s.Close();
            s.Dispose();
            UpdateViews();
            return true;
        }

        public virtual void refreshData()
        {
            //ocistim sve tabele
            clinicPatients.Rows.Clear();
            clinicPatients.Columns.Clear();
            clinicQueue.Rows.Clear();
            clinicQueue.Columns.Clear();
            patientVaccines.Rows.Clear();
            patientVaccines.Columns.Clear();
            patientDiagnosis.Columns.Clear();
            patientDiagnosis.Rows.Clear();
            patientTherapies.Columns.Clear();
            patientTherapies.Rows.Clear();
            patientClinics.Columns.Clear();
            patientClinics.Rows.Clear();
            patientMedicines.Rows.Clear();
            patientMedicines.Columns.Clear();
            ISession s = DataLayer.GetSession();
            s.Refresh(user);
            //tabela za trenutne pacijente na klinici
            clinicPatients.Columns.Add("JMBG");
            clinicPatients.Columns.Add("IME");
            clinicPatients.Columns.Add("PREZIME");
            clinicPatients.Columns.Add("BROJ KREVETA");
            clinicPatients.Columns.Add("DATUM PRIJEMA");
            clinicPatients.Columns.Add("OCEKIVANI BORAVAK");

            foreach (BoraviNaKlinici b in user.Klinika.Pacijenti)
            {
                if(b.DatumOtpusta==null)
                    clinicPatients.Rows.Add(b.Pacijent.JMBG, b.Pacijent.Ime, b.Pacijent.Prezime, b.BrojKreveta, b.DatumPrijema, b.OcekivaniBoravak);
            }
            //slobodan broj kreveta
            int sum = user.Klinika.KoristiKrevete.Count;
            int used = user.Klinika.Pacijenti.Where(x => x.DatumOtpusta == null).Count();
            sum -= used;
            vacantbeds = sum;
            //tabela za listu cekanja
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
            //trazeni pacijent iz Doma zdravlja(mySql)
            if (patient != null)
            {
                ISession ss = DataLayerMySQL.GetSession();
                ss.Refresh(patient);
                patientVaccines.Columns.Add("SIFRA VAKCINE");
                patientVaccines.Columns.Add("IME");
                patientVaccines.Columns.Add("DATUM PRIMANJA");
                foreach(PrimioVakcinu vak in patient.PrimioVakcinuVakcine)
                {
                    patientVaccines.Rows.Add(vak.Id.PrimioVakcina.Sifra, vak.Id.PrimioVakcina.Ime, vak.Datum.ToString("dd/MM/yyyy"));
                }

                patientDiagnosis.Columns.Add("SIFRA DIJAGNOZE");
                patientDiagnosis.Columns.Add("IME");
                patientDiagnosis.Columns.Add("DATUM");
                patientDiagnosis.Columns.Add("LEKAR");
                foreach(Dijagnostifikovano dij in patient.DijagnostifikovanoDijagnoze)
                {
                    patientDiagnosis.Rows.Add(dij.Id.DijagnozaDijagnoza.Sifra, dij.Id.DijagnozaDijagnoza.Ime, dij.Datum.ToString("dd/MM/yyyy"), dij.Id.DijagnozaLekar.Ime + " " + dij.Id.DijagnozaLekar.Prezime);
                }

                patientTherapies.Columns.Add("OPIS");
                patientTherapies.Columns.Add("DATUM_OD");
                patientTherapies.Columns.Add("DATUM_DO");
                patientTherapies.Columns.Add("LEKAR");
                foreach(Terapija ter in patient.Terapije)
                {
                    patientTherapies.Rows.Add(ter.Opis, ter.Datum_od.ToString("dd/MM/yyyy"), ter.Datum_do.ToString("dd/MM/yyyy"), ter.TerapijaLekar.Ime + " " + ter.TerapijaLekar.Prezime);
                }
                NHibernateUtil.Initialize(patient.Lekar);
                NHibernateUtil.Initialize(patient.Lekar.RadiUDomuZdravlja);
                ss.Close();ss.Dispose();
            }
            if (clinicPatient != null)
            {
                s.Refresh(clinicPatient);
                patientClinics.Columns.Add("NAZIV KLINIKE");
                patientClinics.Columns.Add("DATUM_PRIJEMA");
                patientClinics.Columns.Add("DATUM_OTPUSTA");
                foreach(BoraviNaKlinici bk in clinicPatient.Klinike)
                {
                    patientClinics.Rows.Add(bk.Klinika.Naziv,bk.DatumPrijema.ToString("dd/MM/yyyy"),bk.DatumOtpusta.ToString());
                }
                NHibernateUtil.Initialize(clinicPatient.Rodjak);

                patientMedicines.Columns.Clear();
                patientMedicines.Rows.Clear();
                patientMedicines.Columns.Add("LEK");
                patientMedicines.Columns.Add("DATUM OD");
                patientMedicines.Columns.Add("DATUM_DO");
                foreach(PacijentUzimaLekove pul in clinicPatient.Lekovi)
                {
                    patientMedicines.Rows.Add(pul.Lek.Naziv, pul.DatumOd.ToString("dd/MM/yyyy"), pul.DatumDo.ToString("dd/MM/yyyy"));
                }
            }

            s.Close();s.Dispose();
        }
    }
}
