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
        DataTable clinicEmployeeShifts;
        DataTable clinicEmpolyees;
        DataTable clinicBeds;
        DataTable clinicMedicalStorage;

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
            //Kreveti
            clinicBeds = new DataTable("KREVETI");
            clinicBeds.Columns.Add("BROJ");
            clinicBeds.Columns.Add("SLOBODAN");
            //Magacin
            clinicMedicalStorage = new DataTable("MAGACIN");
            clinicMedicalStorage.Columns.Add("NAZIV");
            clinicMedicalStorage.Columns.Add("OPIS");
            clinicMedicalStorage.Columns.Add("TIP MATERIJALA");
            clinicMedicalStorage.Columns.Add("NACIN UZIMANJA");
            clinicMedicalStorage.Columns.Add("TIPICNA DOZA");
            clinicMedicalStorage.Columns.Add("KRITICNI NIVO ZA NARUCIVANJE");
            clinicMedicalStorage.Columns.Add("CENA PO JEDINICI");
            clinicMedicalStorage.Columns.Add("KOLICINA");

        }
        public GlavnaSestraModel(Zaposleni user) : this()
        {
            this.user = user;
        }

        public DataTable Employees
        {
            get
            {
                return clinicEmpolyees;
            }
        }
        public DataTable Shifts
        {
            get
            {
                return Shifts;
            }
        }
        public DataTable BedsAtClinic
        {
            get
            {
                return clinicBeds;
            }
        }
        public DataTable ClinicStorage
        {
            get
            {
                return clinicMedicalStorage;
            }
        }

        public bool addShift(int EmployeeId, DateTime startDate, DateTime endDate, string ShiftType)
        {
            if (startDate > endDate)
                return false; //pocetni datum je posle krajnjeg
            ISession s = DataLayer.GetSession();

            Zaposleni z = s.QueryOver<Zaposleni>().Where(x => x.Id == EmployeeId).SingleOrDefault<Zaposleni>();
            if (z == null)
            {
                s.Close();
                s.Dispose();
                return false; //nema ga zaposleni sa tim ID-jem
            }
            foreach(Smena shift in z.Smene)
            {
                if (shift.DatumDo > startDate)
                {
                    s.Close();
                    s.Dispose();
                    return false; //nije moguce dodati smenu pre zavrsetka poslednje smene
                }
            }
            Smena shiftadd = new Smena()
            {
                DatumDo = endDate,
                DatumOd = startDate,
                Zaposleni = z,
                TipSmene = ShiftType
            };
            
            z.Smene.Add(shiftadd);
            s.Save(shiftadd);
            s.SaveOrUpdate(z);
            s.Flush();
            s.Close();
            s.Dispose();

            return true;
        }
        public bool addBed(int BedID) 
        {
            ISession s = DataLayer.GetSession();
            Krevet k = s.QueryOver<Krevet>().Where(x => x.Id == BedID).SingleOrDefault<Krevet>();
            if (k == null) //ne postoji krevet sa tim ID-jem
            {
                s.Close();
                s.Dispose();
                return false;
            }
            if (k.Klinika.Id == user.Klinika.Id)
            {
                s.Close();
                s.Dispose();
                return false;//krevet je vec na klinici
            }
            foreach(BoraviNaKlinici bk in k.Klinika.Pacijenti)
            {
                if (bk.BrojKreveta == k.Id)
                {
                    s.Close();
                    s.Dispose();
                    return false; //krevet je zauzet
                }
            }
            k.Klinika = user.Klinika;
            user.Klinika.KoristiKrevete.Add(k);
            s.SaveOrUpdate(user.Klinika);
            s.SaveOrUpdate(k);
            s.Flush();
            s.Close();
            s.Dispose();

            return true;
        }

        public bool AddMedicalSupplies(int Id,int quantity)
        {


            return true;
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
                    clinicEmpolyees.Rows.Add(u.Zaposleni.Id.ToString(), u.Zaposleni.Ime, u.Zaposleni.Prezime,
                        u.Zaposleni.DatumRodjenja.ToString("dd/MM/yyyy"), u.Zaposleni.TipZaposlenog);
            }
            //clinicEmployeeShifts
            foreach (Smena smena in user.Smene)
            {
                clinicEmployeeShifts.Rows.Add(smena.Id.ToString(), smena.DatumOd.ToString("dd/MM/yyyy"), smena.DatumDo.ToString("dd/MM/yyyy"), smena.TipSmene);
            }
            //clinic beds
            foreach(Krevet k in user.Klinika.KoristiKrevete)
            {
                bool empty = true;
                string patientJMBG = "";
                foreach(BoraviNaKlinici bk in user.Klinika.Pacijenti)
                {
                    if (k.Id == bk.BrojKreveta)
                    {
                        empty = false;
                        patientJMBG = bk.Pacijent.JMBG;
                    }
                }
                if (empty)
                    clinicBeds.Rows.Add(k.Id.ToString(), "DA");
                else
                    clinicBeds.Rows.Add(k.Id.ToString(), patientJMBG);
            }
            //magacin
            foreach(MagacinKlinikeSadrzi pm in user.Klinika.Magacin.PotrosniMaterijal)
            {
                clinicMedicalStorage.Rows.Add(pm.PotrosniMaterijal.Naziv, pm.PotrosniMaterijal.Opis, pm.PotrosniMaterijal.TipMaterijala, pm.PotrosniMaterijal.NacinUzimanja, pm.PotrosniMaterijal.TipicnaDoza, pm.PotrosniMaterijal.KriticniNivoZaNarucivanje.ToString(), pm.PotrosniMaterijal.CenaPoJedinici.ToString(),pm.Kolicina.ToString());
            }


        }
    }
}
