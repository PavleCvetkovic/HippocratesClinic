using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
using SBP2017.Hippocrates.Bolnica.View;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    public class SpecijalistaModel : SestraBolnicarModel
    {
        private new Specijalista user; //sakriva zaposlenog iz osnovne klase specijalistom
        private DataTable doctorExams;
        private List<int> doctorAvailableTimes;        
        private DateTime datumPretragePregleda; //uvek ce da predstavlja trenutno izabrani datum
        private DataTable dtAvailableTimes;

        #region Properties
        public DateTime DatumPretragePregleda {
            get { return datumPretragePregleda; }
            set { this.datumPretragePregleda = value; refreshData(); }
        }    
           
        public Specijalista User { get { return this.user; } }

        public DataTable DoctorExams { get { return this.doctorExams; } }
        public DataTable DoctorAvailableTimes { get { return this.dtAvailableTimes; } }
        #endregion

        public SpecijalistaModel() : base()
        {
            //Pregledi lekara
            doctorExams = new DataTable("Zakazani pregledi specijaliste");
            doctorExams.Columns.Add("ID");
            doctorExams.Columns.Add("Datum");
            doctorExams.Columns.Add("Vreme");
            doctorExams.Columns.Add("Prostorija");
            //Slobodni termini za zakazivanje
            doctorAvailableTimes = new List<int>();
            datumPretragePregleda = DateTime.Today;
            dtAvailableTimes = new DataTable("Slobodni termini");
            dtAvailableTimes.Columns.Add("Vreme");
        }

        public SpecijalistaModel(Specijalista sp) : this()
        {
            views = new List<IView>();
            this.user = sp;
            base.user = sp as Zaposleni;
        }

        public override void refreshData()
        {
            base.refreshData();
            doctorExams.Rows.Clear();
            doctorAvailableTimes.Clear();
            dtAvailableTimes.Rows.Clear();

            ISession s = DataLayer.GetSession();
            s.Refresh(user);

            //doctorExams
            IList<Pregled> pregledi =
                s.QueryOver<Pregled>()
                    .Where(c => c.Specijalista.Id == user.Id && c.Datum == datumPretragePregleda)
                    .List();
            //eksplicitno ucitavanje klinike , kc, i pacijenata
            NHibernateUtil.Initialize(user.Klinika.KlinickiCentar);
            NHibernateUtil.Initialize(user.Klinika.GlavnaSestraKlinike);
            NHibernateUtil.Initialize(user.Klinika.Pacijenti);
            s.Close();
            foreach (Pregled pregled in pregledi)
            {
                string tmp = (pregled.Vreme / 100).ToString() + ":";
                if (pregled.Vreme % 100 == 0)
                    tmp += "00";
                else
                    tmp += (pregled.Vreme % 100).ToString();
                doctorExams.Rows.Add(pregled.Id,
                    pregled.Datum.Day + "." + pregled.Datum.Month + "." + pregled.Datum.Year, tmp, pregled.Prostorija);
            }
            //doctorAvailableTimes
            availableTimes();
            foreach (int time in doctorAvailableTimes)
            {
                string pom = time.ToString();
                if (pom.Length == 3)
                {
                    pom = pom.Insert(1, ":");
                }
                else //pom.Length == 4
                {
                    pom = pom.Insert(2, ":");
                }
                dtAvailableTimes.Rows.Add(pom);
            }

            
        }

        public Smena findShiftForDate()
        {
            
            ISession s = DataLayer.GetSession();
            IList<Smena> smene = s.QueryOver<Smena>()
                .Where(c=>c.Zaposleni == user)
                .List();
            foreach (Smena smena in smene)
            {
                if (smena.DatumOd <= datumPretragePregleda && smena.DatumDo >= datumPretragePregleda)
                {                   
                    s.Close();
                    return smena;
                }
            }
            s.Close();
            return null;
        }

        public void availableTimes()
        {
            Smena smena = findShiftForDate();
            if (smena != null) //ako je null onda za izabrani datum nije definisana smena
            {
                if (smena.TipSmene.Equals("1"))
                {
                    int j = 0;
                    for (int i = 7; i < 13;)
                    {
                        j += 45;
                        if (j / 60 >= 1)
                        {
                            j = j % 60;
                            i++;                            
                        }            
                            doctorAvailableTimes.Add(i*100 + j);
                    }
                }
                else if(smena.TipSmene.Equals("2"))
                {
                    int j = 0;
                    for (int i = 14; i < 18;)
                    {
                        j += 45;
                        if (j / 60 >= 1)
                        {
                            j = j % 60;
                            i++;
                        }
                            doctorAvailableTimes.Add(i * 100 + j);
                    }
                }
                foreach (DataRow pregled in doctorExams.Rows)
                {
                    //jer se slobodni termini cuvaju kao List<int>, eg 715 je 7:15
                    string pom = pregled["Vreme"].ToString();
                    if (pom.Length == 5) // xx:xx
                    {
                        pom = pom.Remove(2, 1);
                    }
                    else // x:xx
                    {
                        pom = pom.Remove(1, 1);
                    }
                    doctorAvailableTimes.Remove(Int32.Parse(pom));
                }
            }
        }

        public bool scheduleNewExam(int time) //int je jer se u bazi tako upisuje
        {
            ISession s = DataLayer.GetSession();
            if (base.clinicPatient == null)
            {
                return false;
            }
            Pregled p = new Pregled();
            p.Specijalista = user;
            p.Pacijent = base.clinicPatient;
            p.Datum = datumPretragePregleda;
            p.Vreme = time;
            p.Prostorija = user.BrojOrdinacije; //ova verzija f-je uzima default ordinaciju specijaliste

            s.Save(p);
            s.Flush();
            s.Close();

            refreshData();
            return true;
        }

        public void addNewMedication(int idLeka, DateTime datumDo)
        {
            ISession s = DataLayer.GetSession();
            PotrosniMaterijal lek = s.QueryOver<PotrosniMaterijal>().
                Where(x => x.Id == idLeka).
                SingleOrDefault<PotrosniMaterijal>();
            PacijentUzimaLekove pl = new PacijentUzimaLekove()
            {
                Pacijent = base.ClinicPatient,
                Lek = lek,
                DatumOd = DateTime.Today,
                DatumDo = datumDo
                
            };
            base.ClinicPatient.Lekovi.Add(pl);
            s.SaveOrUpdate(base.ClinicPatient);
            s.Close();
        }

        public void deleteMedication(int idLek)
        {
            ISession s = DataLayer.GetSession();
            PacijentUzimaLekove pl = s.Load<PacijentUzimaLekove>(idLek);
            s.Delete(pl);
            s.Flush();
            base.clinicPatient.Lekovi.Remove(pl);
            s.Close();
        }
    }
}
