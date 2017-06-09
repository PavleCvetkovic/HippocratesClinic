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
using SBP2017.Hippocrates.Bolnica.View;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    public class SpecijalistaModel : SestraBolnicarModel
    {
        new private Specijalista user; //sakriva zaposlenog iz osnovne klase specijalistom
        private DataTable doctorExams;
        private List<int> doctorAvailableTimes;        
        private DateTime datumPretragePregleda; //uvek ce da predstavlja trenutno izabrani datum

        public DateTime DatumPretragePregleda {
            get { return datumPretragePregleda; } set { this.datumPretragePregleda = value; } }       
       

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
            
        }

        public SpecijalistaModel(Specijalista sp) : this()
        {
            views = new List<IView>();
            this.user = sp;
        }

        public override void refreshData()
        {
            base.refreshData();
            doctorExams.Rows.Clear();

            ISession s = DataLayer.GetSession();
            s.Refresh(user);

            //doctorExams
            IQueryOver<Pregled> query =
                QueryOver.Of<Pregled>().Where(c => c.Specijalista.Id == user.Id && c.Datum == datumPretragePregleda);
            foreach (Pregled pregled in query.List<Pregled>())
            {
                doctorExams.Rows.Add(pregled.Id, pregled.Datum, pregled.Vreme, pregled.Prostorija);
            }
            //doctorAvailableTimes
            availableTimes();

        }

        public Smena findShiftForDate()
        {
            
            ISession s = DataLayer.GetSession();
            IQueryOver<Smena> query = QueryOver.Of<Smena>().Where(c=>c.Zaposleni == user);
            foreach (Smena smena in query.List<Smena>())
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
                if (smena.TipSmene.Equals("PRVA"))
                {
                    for (int i = 700; i <= 1315; i += 45) { doctorAvailableTimes.Add(i); }
                }
                else
                {
                    for (int i = 1400; i <= 1815; i += 45) { doctorAvailableTimes.Add(i); }
                }
                foreach (DataRow pregled in doctorExams.Rows)
                {
                    doctorAvailableTimes.Remove((int)pregled["Vreme"]);
                }
            }
        }



        public void scheduleNewExam(PacijentKlinickogCentra patient, int time) //int je jer se u bazi tako upisuje
        {
            ISession s = DataLayer.GetSession();

            Pregled p = new Pregled();
            p.Specijalista = user;
            p.Pacijent = patient;
            p.Datum = datumPretragePregleda;
            p.Vreme = time;
            p.Prostorija = user.BrojOrdinacije; //ova verzija f-je uzima default ordinaciju specijaliste

            s.Save(p);
            s.Flush();
            s.Close();

            refreshData();
        }
    }
}
