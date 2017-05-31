using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Impl;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    public class GlavnaSestraModel : SestraBolnicarModel
    {
        private DataTable clinicEmployeeShifts;
        private DataTable clinicEmpolyees;

        public GlavnaSestraModel() : base()
        {
            //Zaposleni
            clinicEmpolyees = new DataTable("Zaposleni na klinici");
            clinicEmpolyees.Columns.Add("ID");
            clinicEmpolyees.Columns.Add("Ime");
            clinicEmpolyees.Columns.Add("Prezime");
            clinicEmpolyees.Columns.Add("Datum rodjenja");
            clinicEmpolyees.Columns.Add("Tip zaposlenog");
            //Smene       
            clinicEmployeeShifts = new DataTable("Smene zaposlenih na klinici");
            clinicEmployeeShifts.Columns.Add("ID");
            clinicEmployeeShifts.Columns.Add("Datum od");
            clinicEmployeeShifts.Columns.Add("Datum do");
            clinicEmployeeShifts.Columns.Add("Tip smene");
        }

        public override void refreshData()
        {
            base.refreshData();
            clinicEmpolyees.Rows.Clear();
            clinicEmployeeShifts.Rows.Clear();

            ISession s = DataLayer.GetSession();            
            s.Refresh(user);
            //clinicEmployee
            foreach (Ugovor u in user.Klinika.KlinickiCentar.Ugovori)
            {
                if (u.Zaposleni.Klinika == user.Klinika)
                    clinicEmpolyees.Rows.Add(u.Zaposleni.Id, u.Zaposleni.Ime, u.Zaposleni.Prezime,
                        u.Zaposleni.DatumRodjenja, u.Zaposleni.TipZaposlenog);
            }
            //clinicEmployeeShifts
            foreach (Smena smena in user.Smene)
            {
                clinicEmployeeShifts.Rows.Add(smena.Id, smena.DatumOd, smena.DatumDo, smena.TipSmene);
            }


        }
    }
}
