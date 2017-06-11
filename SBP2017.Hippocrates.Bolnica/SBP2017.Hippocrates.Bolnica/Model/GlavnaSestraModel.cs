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
        protected DataTable clinicEmployeeShifts;
        protected DataTable clinicEmployees;
        protected DataTable clinicBeds;
        protected DataTable clinicMedicalStorage;
        protected DataTable clinicMedicines;

        protected DataTable orders;
        protected DataTable otherBeds;
        protected DataTable centralStorage;

        public GlavnaSestraModel() : base()
        {
            //Zaposleni
            clinicEmployees = new DataTable("Zaposleni na klinici");
            clinicEmployees.Columns.Add("ID");
            clinicEmployees.Columns.Add("Ime");
            clinicEmployees.Columns.Add("Prezime");
            clinicEmployees.Columns.Add("Datum rodjenja");
            clinicEmployees.Columns.Add("Tip zaposlenog");
            //Smene       
            clinicEmployeeShifts = new DataTable("Smene zaposlenih na klinici");
            clinicEmployeeShifts.Columns.Add("ID");
            clinicEmployeeShifts.Columns.Add("IME");
            clinicEmployeeShifts.Columns.Add("PREZIME");
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
            //Lekovi koji se koriste na klinici
            clinicMedicines = new DataTable("LEKOVI NA KLINICI");
            clinicMedicines.Columns.Add("LEK");
            clinicMedicines.Columns.Add("IME");
            clinicMedicines.Columns.Add("PREZIME");
            clinicMedicines.Columns.Add("DATUM OD");
            clinicMedicines.Columns.Add("DATUM DO");
            //narudzbenice
            orders = new DataTable("NARUDZBENICE");
            orders.Columns.Add("ID");
            orders.Columns.Add("NAZIV");
            orders.Columns.Add("OPIS");
            orders.Columns.Add("KLINIKA");
            orders.Columns.Add("DATUM");
            orders.Columns.Add("DATUM ISPORUKE");
            orders.Columns.Add("CENA");
            orders.Columns.Add("KOLICINA");
            //svi slobodni kreveti u okviru KC
            otherBeds = new DataTable("SLOBODNI KREVETI");
            otherBeds.Columns.Add("BROJ");
            otherBeds.Columns.Add("KLINIKA");
            //CENTRALNI MAGACIN
            centralStorage = new DataTable("CENTRALNI MAGACIN");
            centralStorage.Columns.Add("ID");
            centralStorage.Columns.Add("NAZIV");
            centralStorage.Columns.Add("OPIS");
            centralStorage.Columns.Add("CENA PO JEDINICI");
            centralStorage.Columns.Add("KRITICNI NIVO ZA NARUCIVANJE");
            centralStorage.Columns.Add("TIP MATERIJALA");
            centralStorage.Columns.Add("NACIN UZIMANJA");
            centralStorage.Columns.Add("TIPICNA DOZA");
        }
        public GlavnaSestraModel(Zaposleni user) : this()
        {
            this.user = user;
        }

        public DataTable Orders
        {
            get
            {
                return orders;
            }
        }
        public DataTable Employees
        {
            get
            {
                return clinicEmployees;
            }
        }
        public DataTable Shifts
        {
            get
            {
                return clinicEmployeeShifts;
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
        public DataTable ClinicMedicines
        {
            get
            {
                return clinicMedicines;
            }
        }

        public bool addShift(int EmployeeId, DateTime startDate, DateTime endDate, string ShiftType)
        {
            if (startDate.Date > endDate.Date)
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
                if (shift.DatumDo.Date > startDate.Date)
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
            UpdateViews();
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
            UpdateViews();
            return true;
        }
        public bool deleteShift(string ShiftId)
        {
            ISession s = DataLayer.GetSession();
            Smena smena = s.Get<Smena>(Int32.Parse(ShiftId));
            s.Delete(smena);
            s.Flush();
            s.Close();
            s.Dispose();
            UpdateViews();
            return true;
        }

        public bool AddMedicalSupplies(int Id,int quantity)
        {


            return true;
        }
       /* public void refreshOtherBeds()
        {
            otherBeds.Rows.Clear();
        }*/
        public override void refreshData()
        {
            base.refreshData();
            clinicEmployees.Rows.Clear();
            clinicEmployeeShifts.Rows.Clear();
            clinicBeds.Rows.Clear();
            clinicEmployeeShifts.Rows.Clear();
            clinicMedicines.Rows.Clear();
            otherBeds.Rows.Clear();
            centralStorage.Rows.Clear();
            orders.Rows.Clear();

            ISession s = DataLayer.GetSession();            
            s.Refresh(user);
            //clinicEmployee
            foreach (Ugovor u in user.Klinika.KlinickiCentar.Ugovori)
            {
                if (u.Zaposleni.Klinika == user.Klinika)
                    clinicEmployees.Rows.Add(u.Zaposleni.Id.ToString(), u.Zaposleni.Ime, u.Zaposleni.Prezime,
                        u.Zaposleni.DatumRodjenja.ToString("dd/MM/yyyy"), u.Zaposleni.TipZaposlenog);
            }
            //clinicEmployeeShifts
            foreach (Ugovor zap in user.Klinika.KlinickiCentar.Ugovori) {
                foreach (Smena smena in zap.Zaposleni.Smene)
                {
                    clinicEmployeeShifts.Rows.Add(smena.Id.ToString(), smena.Zaposleni.Ime, smena.Zaposleni.Prezime, smena.DatumOd.ToString("dd/MM/yyyy"), smena.DatumDo.ToString("dd/MM/yyyy"), smena.TipSmene);
                }
            }
            //clinic beds
            foreach(Krevet k in user.Klinika.KoristiKrevete)
            {
                bool empty = true;
                string patientJMBG = "";
                foreach (BoraviNaKlinici bk in user.Klinika.Pacijenti)
                {
                    if (k.Id == bk.BrojKreveta)
                    {
                        empty = false;
                        patientJMBG = bk.Pacijent.JMBG;
                    }
                    else
                        empty = true;
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
            //lekovi koji se koriste na klinici
            foreach(BoraviNaKlinici bk in user.Klinika.Pacijenti)
            {
                foreach(PacijentUzimaLekove pul in bk.Pacijent.Lekovi)
                {
                    clinicMedicines.Rows.Add(pul.Lek.Naziv, bk.Pacijent.Ime, bk.Pacijent.Prezime, pul.DatumOd.ToString("dd/MM/yyyy"), pul.DatumDo.ToString("dd/MM/yyyy"));
                }
            }
            //narudzbenice
            foreach(Narudzbenica nar in user.Klinika.Narudzbenice)
            {
                orders.Rows.Add(nar.Id, nar.Naziv, nar.Opis, nar.ImeKlinike, nar.DatumNarudzbine.ToString("dd/MM/yyyy"), nar.DatumIsporuke.ToString("dd/MM/yyyy"), nar.Cena, nar.Kolicina);
            }
            //svi slobodni kreveti u okviru KC
            bool slobodan = true;
            foreach(Klinika k in user.Klinika.KlinickiCentar.Klinike)
            {
                if (k.Id != user.Klinika.Id)
                {
                    foreach(Krevet krev in k.KoristiKrevete)
                    {
                        slobodan = true;
                        foreach(BoraviNaKlinici bkk in k.Pacijenti)
                        {
                            if (krev.Id == bkk.BrojKreveta)
                                slobodan = false;
                        }
                        if (slobodan)
                            otherBeds.Rows.Add(krev.Id, k.Naziv);
                    }
                }
            }
            //CENTRALNI MAGACIN
            foreach(PotrosniMaterijal pm in user.Klinika.KlinickiCentar.CentralniMagacin.Materijal)
            {
                centralStorage.Rows.Add(pm.Id, pm.Naziv, pm.Opis, pm.CenaPoJedinici, pm.KriticniNivoZaNarucivanje, pm.TipMaterijala, pm.NacinUzimanja, pm.TipicnaDoza);
            }

            s.Close();
            s.Dispose();
        }
    }
}
