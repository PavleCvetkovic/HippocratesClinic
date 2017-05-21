using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using SBP2017.Hippocrates.Bolnica.Controller;
using SBP2017.Hippocrates.Bolnica.Model;
using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
namespace SBP2017.Hippocrates.Bolnica.View
{
    public partial class SestraBolnicar : MetroForm,IView
    {
        private IController controller;
        public SestraBolnicar()
        {
            InitializeComponent();
        }
        public SestraBolnicar(IController controller)
            : this()
        {
            AddControler(controller);
        }

        public void AddControler(IController controller)
        {
            this.controller = controller;
        }

        public void AttachToModel(IModel model)
        {
            model.AddView(this);
        }
        public new void  Update()
        {
            SestraBolnicarModel m = (controller.getModel() as SestraBolnicarModel);
            controller.refreshData();
            lblUserName.Text = m.User.Ime +" "+ m.User.Prezime;
            dgvPatients.DataSource = m.ClinicPatients;
            dgvQueue.DataSource = m.ClinicQueue;
            lblCCName.Text = m.User.Klinika.KlinickiCentar.Ime;
            lblClinicName.Text = m.User.Klinika.Naziv;
            lblCSName.Text = m.User.Klinika.GlavnaSestraKlinike.Ime + " " + m.User.Klinika.GlavnaSestraKlinike.Prezime;
            lblAdressClinic.Text = m.User.Klinika.Lokacija;
            lblVacantBeds.Text = m.VacantBeds.ToString();

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
            if(m.ClinicPatient!=null)//Ima ga i u evidinciji klinickog
            {
                dgvClinics.DataSource = m.PatientClinics;
                if(m.ClinicPatient.Rodjak!=null) //moze pacijent da nema rodjaka
                    lblCousin.Text = m.ClinicPatient.Rodjak.Ime +" "+ m.ClinicPatient.Rodjak.Prezime +" "+ m.ClinicPatient.Rodjak.Telefon;
                dgvMedicines.DataSource = m.PatientMedicines;
            }
        }

        private void SestraBolnicar_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex==-1)
            {
                MetroMessageBox.Show(this, "Izaberite nacin pretrage", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txtSearch.Text=="")
            {
                MetroMessageBox.Show(this, "Polje za pretragu je prazno.","Obavestenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (cmbSearchBy.SelectedIndex == 0)
            {
                if (!(controller as SestraBolnicarController).searchPatientsByJMBG(txtSearch.Text))
                    MetroMessageBox.Show(this, "Ne postoji taj pacijent.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MainTab.SelectedTab = TabPagePatientView;
                return;
            }
            else
            {
                if (cmbSearchBy.SelectedIndex == 1)
                {
                    if (!(controller as SestraBolnicarController).searchPatientsByLBO(txtSearch.Text))
                        MetroMessageBox.Show(this, "Ne postoji taj pacijent.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MainTab.SelectedTab = TabPagePatientView;
                    return;
                }
                else
                {
                    if (!(controller as SestraBolnicarController).searchPatientsByBedNo(txtSearch.Text))
                        MetroMessageBox.Show(this, "Ne postoji taj pacijent.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MainTab.SelectedTab = TabPagePatientView;
                    return;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGoToSearch_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TabPagePatientsSearch;
        }

        private void btnHealthRecords_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "Izaberite pacijenta", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
