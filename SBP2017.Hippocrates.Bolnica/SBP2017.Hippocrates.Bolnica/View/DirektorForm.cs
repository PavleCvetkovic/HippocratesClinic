using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using SBP2017.Hippocrates.Bolnica.Controller;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Model;
using SBP2017.Hippocrates.Bolnica.Pomocne_forme;

namespace SBP2017.Hippocrates.Bolnica.View
{
    public partial class DirektorForm : MetroForm, IView
    {
        private IController controller;
        public DirektorForm()
        {
            InitializeComponent();
        }
        public DirektorForm(IController controller) : this()
        {
            this.controller = controller;
        }
        public void AddControler(IController controller)
        {
            this.controller = controller;
        }

        public void AttachToModel(IModel model)
        {
            model.AddView(this);
        }
        public new void Update()
        {
            DirektorModel m = (controller.getModel() as DirektorModel);
            controller.refreshData();
            lblUserName.Text = m.User.Ime + " " + m.User.Prezime;
            dgvPatients.DataSource = m.ClinicPatients;
            dgvQueue.DataSource = m.ClinicQueue;            
            dgvShifts.DataSource = m.Shifts;
            dgvClinicMedicines.DataSource = m.ClinicMedicines;
            dgvOrders.DataSource = m.Orders;
            dgvCentralStorage.DataSource = m.CentralStorage;

            //direktor
            dgvSuppliers.DataSource = m.Suppliers;
            dgvCClinics.DataSource = m.Clinics;
            dgvAllBeds.DataSource = m.AllBeds;
            dgvEmployees.DataSource = m.AllEmployees;

            if (m.Patient != null) //trazen je pacijent
            {
                lblPatientName.Text = m.Patient.Ime;
                lblPatientSurname.Text = m.Patient.Prezime;
                lblPatientBirthDate.Text = m.Patient.Datum_rodjenja.ToString("dd/MM/yyyy");
                lblDoctor.Text = m.Patient.Lekar.Ime + " " + m.Patient.Lekar.Prezime;
                lblHC.Text = m.Patient.Lekar.RadiUDomuZdravlja.Ime;
                lblPhone.Text = m.Patient.Telefon;
                dgvTherapies.DataSource = m.PatientTherapies;
                dgvVaccines.DataSource = m.PatientsVaccines;
                dgvDiagnosis.DataSource = m.PatientDiagnosis;
            }
            if (m.ClinicPatient != null)//Ima ga i u evidinciji klinickog
            {
                dgvClinics.DataSource = m.PatientClinics;
                if (m.ClinicPatient.Rodjak != null) //moze pacijent da nema rodjaka
                    lblCousin.Text = m.ClinicPatient.Rodjak.Ime + " " + m.ClinicPatient.Rodjak.Prezime + " " + m.ClinicPatient.Rodjak.Telefon;
                dgvMedicines.DataSource = m.PatientMedicines;
            }
        }

        private void GlavnaSestraForm_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void btnHealthRecords_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "Izaberite pacijenta", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!controller.searchPatientsByJMBG(dgvPatients.SelectedRows[0].Cells["JMBG"].Value.ToString()))
                    MetroMessageBox.Show(this, "Greska u sistemu, pacijent ga ima u evidinciji KC a nema u DZ", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MainTab.SelectedTab = TabPagePatientView;
                }
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "Izaberite pacijenta", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                (controller as GlavnaSestraController).dischargePatient(dgvPatients.SelectedRows[0].Cells["JMBG"].Value.ToString());
                MetroMessageBox.Show(this, "Uspesno otpusten sa klinike", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Izaberite nacin pretrage", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSearch.Text == "")
            {
                MetroMessageBox.Show(this, "Polje za pretragu je prazno.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbSearchBy.SelectedIndex == 0)
            {
                if (!(controller).searchPatientsByJMBG(txtSearch.Text))
                    MetroMessageBox.Show(this, "Ne postoji taj pacijent.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MainTab.SelectedTab = TabPagePatientView;
                return;
            }
            else
            {
                if (cmbSearchBy.SelectedIndex == 1)
                {
                    if (!(controller).searchPatientsByLBO(txtSearch.Text))
                        MetroMessageBox.Show(this, "Ne postoji taj pacijent.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MainTab.SelectedTab = TabPagePatientView;
                    return;
                }
                else
                {
                    if (!(controller).searchPatientsByBedNo(txtSearch.Text))
                        MetroMessageBox.Show(this, "Ne postoji taj pacijent.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MainTab.SelectedTab = TabPagePatientView;
                    return;
                }
            }
        }

        private void btnShowMedicalRecords_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "Izaberite pacijenta", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                controller.searchPatientsByJMBG(dgvQueue.SelectedRows[0].Cells["JMBG"].Value.ToString());
            }
            MainTab.SelectedTab = TabPagePatientView;
        }

        private void btnGoToSearch_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TabPagePatientsSearch;
        }

        private void btnAddPatientToClinic_Click(object sender, EventArgs e)
        {
            if ((controller.getModel() as GlavnaSestraModel).Patient == null)
            {
                MetroMessageBox.Show(this, "Mora biti otvoren karton nekog pacijenta", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if ((controller.getModel() as GlavnaSestraModel).VacantBeds <= 0)
            {
                PrimiNaKliniku primlista = new PrimiNaKliniku((controller.getModel() as GlavnaSestraModel).User, (controller.getModel() as GlavnaSestraModel).Patient.Jmbg, true);
                primlista.ShowDialog();
                if (primlista.canceled)
                    return;
                Rodjak rlista = new Rodjak()
                {
                    Ime = primlista.Ime,
                    Prezime = primlista.Prezime,
                    Adresa = primlista.AdresaRodjak,
                    Srodstvo = primlista.Srodstvo,
                    Telefon = primlista.TelefonRodjak
                };
                if (!(controller as GlavnaSestraController).addToQueue((controller.getModel() as GlavnaSestraModel).Patient.Jmbg, rlista, primlista.BracniStatus, primlista.Pol, primlista.AdresaPacijent))
                {
                    MetroMessageBox.Show(this, "Vec postoji u listi cekanja", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MetroMessageBox.Show(this, "Uspesno smesten na listu cekanja", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                primlista.Dispose();
                return;
            }
            PrimiNaKliniku prim = new PrimiNaKliniku((controller.getModel() as GlavnaSestraModel).User, (controller.getModel() as GlavnaSestraModel).Patient.Jmbg);
            prim.ShowDialog();
            if (prim.canceled)
                return;
            Rodjak r = new Rodjak()
            {
                Ime = prim.Ime,
                Prezime = prim.Prezime,
                Adresa = prim.AdresaRodjak,
                Srodstvo = prim.Srodstvo,
                Telefon = prim.TelefonRodjak
            };
            if (!(controller as GlavnaSestraController).acceptPatient((controller.getModel() as GlavnaSestraModel).Patient.Jmbg, r, prim.BracniStatus, prim.Pol, prim.AdresaPacijent, Int32.Parse(prim.BrojKreveta), Int32.Parse(prim.Boravak)))
            {
                MetroMessageBox.Show(this, "Pacijent je vec na klinici", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MetroMessageBox.Show(this, "Uspesno smesten na kliniku", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            prim.Dispose();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "", "Izaberitie zaposlenog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbShift.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "", "Izaberitie tip smene", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(controller as GlavnaSestraController).AddShift(Int32.Parse(dgvEmployees.SelectedRows[0].Cells["ID"].Value.ToString()), dtpFrom.Value, dtpTo.Value, (cmbShift.SelectedIndex + 1).ToString()))
            {
                MetroMessageBox.Show(this, "", "Nije moguce dodati smenu, proverite da li vec postoji ili da li su datumi validni!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MetroMessageBox.Show(this, "", "Uspesno ste dodali smenu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            if (dgvShifts.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "Izaberite smenu", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((controller as GlavnaSestraController).DeleteShift(dgvShifts.SelectedRows[0].Cells["ID"].Value.ToString()))
                MetroMessageBox.Show(this, "Smena uspesno obrisana", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MetroMessageBox.Show(this, "Doslo je do greske", "EROR!!1", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAcceptFromQueue_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count <= 0)
            {
                MetroMessageBox.Show(this, "Izaberite pacijenta", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((controller.getModel() as GlavnaSestraModel).VacantBeds <= 0)
            {
                MetroMessageBox.Show(this, "Nema slobodnih kreveta na klinici", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrimiNaKliniku prim = new PrimiNaKliniku((controller.getModel() as GlavnaSestraModel).User, dgvQueue.SelectedRows[0].Cells["JMBG"].Value.ToString());
            prim.ShowDialog();
            if (prim.canceled)
                return;
            if ((controller as GlavnaSestraController).AcceptFromQueue(dgvQueue.SelectedRows[0].Cells["JMBG"].Value.ToString(), Int32.Parse(prim.BrojKreveta.ToString()), Int32.Parse(prim.Boravak)))
            {
                MetroMessageBox.Show(this, "Uspesno smesten na kliniku", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroMessageBox.Show(this, "Nema mesta na klinici", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            prim.Dispose();
        }

        private void btdAddShiftFocus_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TabPageShifts;
        }

        private void btnOrderFromCS_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                MetroMessageBox.Show(this, "Izaberite kolicinu", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvCentralStorage.SelectedRows.Count <= 0)
            {
                MetroMessageBox.Show(this, "Izaberite materijal", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((controller as GlavnaSestraController).OrderMedicalSupplies(Int32.Parse(dgvCentralStorage.SelectedRows[0].Cells["ID"].Value.ToString()), Int32.Parse(txtQuantity.Text)))
            {
                MetroMessageBox.Show(this, "Uspesno ste narucili", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MetroMessageBox.Show(this, "Ne mozete da narucite", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnAcceptMedicalSuppliesOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count <= 0)
            {
                MetroMessageBox.Show(this, "Izaberite narudzbenicu", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((controller as GlavnaSestraController).AddMedicalSupplies(Int32.Parse(dgvOrders.SelectedRows[0].Cells["ID"].Value.ToString())))
            {
                MetroMessageBox.Show(this, "Uspesno odobrena narudzbenica", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MetroMessageBox.Show(this, "Nije moguce odobriti", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnAddBedToClinic_Click(object sender, EventArgs e)
        {
            if (dgvAllBeds.SelectedRows.Count <= 0)
            {
                MetroMessageBox.Show(this, "Izaberite krevet", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (
                (controller as DirektorController).AddBed(
                    Int32.Parse(dgvAllBeds.SelectedRows[0].Cells["BROJ"].Value.ToString()),
                    Int32.Parse(dgvCClinics.SelectedRows[0].Cells["ID"].Value.ToString())))
            {
                MetroMessageBox.Show(this, "Uspesno premesten krevet", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MetroMessageBox.Show(this, "Nije moguce premestiti krevet", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TabPageOrder;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {            
            DodajDobavljacaForm dobform = new DodajDobavljacaForm();
            dobform.ShowDialog();
            if (dobform.Canceled)
            {
                dobform.Dispose();
            }
            else
            {
                (controller as DirektorController).AddSupplier(dobform.IdDobavljaca);
                dobform.Dispose();
            }
            Update();
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(dgvSuppliers.SelectedRows[0].Cells["ID"].Value.ToString());

            (controller as DirektorController).DeleteSupplier(id);

            Update();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            DodajZaposlenogForm dodaj = new DodajZaposlenogForm((controller.getModel() as DirektorModel).User);
            dodaj.ShowDialog();
            MetroMessageBox.Show(this, "Zaposleni je uspesno dodat", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Update();
        }

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            if (
                (controller as DirektorController).FireEmployee(
                    Int32.Parse(dgvEmployees.SelectedRows[0].Cells["ID"].Value.ToString()))) 
            {
                MetroMessageBox.Show(this, "Zaposleni je uspesno obrisan", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            Update();
        }
    }
}
