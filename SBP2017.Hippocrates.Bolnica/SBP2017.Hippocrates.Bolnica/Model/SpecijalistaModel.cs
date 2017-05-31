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

namespace SBP2017.Hippocrates.Bolnica.Model
{
    public class SpecijalistaModel : SestraBolnicarModel
    {
        private Specijalista user; //sakriva zaposlenog iz osnovne klase specijalistom
        private DataTable doctorExams;
        public DateTime datumPretragePregleda;

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
        }

        public override void refreshData()
        {
            base.refreshData();
            doctorExams.Rows.Clear();

            ISession s = DataLayer.GetSession();
            s.Refresh(user);

            /*//doctorExams
            IQueryOver<Pregled> query =
                QueryOver.Of<Pregled>().Where(c => c.Specijalista.Id == user.Id && c.Datum == datumPretragePregleda);
            foreach (Pregled pregled in query)
            {
                doctorExams.Rows.Add(pregled.Id, pregled.Datum, pregled.Vreme, pregled.Prostorija);
            }*/

        }
    }
}
