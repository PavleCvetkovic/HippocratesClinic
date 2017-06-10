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
using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data.EntitetiMySql;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Controller;
using SBP2017.Hippocrates.Bolnica.Model;

namespace SBP2017.Hippocrates.Bolnica.View
{
    public partial class GlavnaSestraForm : MetroForm,IView
    {
        private IController controller;
        public GlavnaSestraForm()
        {
            InitializeComponent();
        }
        public GlavnaSestraForm(IController controller) : this()
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
            GlavnaSestraModel m = (controller.getModel() as GlavnaSestraModel);
            controller.refreshData();
            lblUserName.Text = m.User.Ime + " " + m.User.Prezime;
            dgvPatients.DataSource = m.ClinicPatients;
            dgvQueue.DataSource = m.ClinicQueue;
            dgvEmployees.DataSource = m.Employees;

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
            if (m.ClinicPatient != null)//Ima ga i u evidinciji klinickog
            {
                dgvClinics.DataSource = m.PatientClinics;
                if (m.ClinicPatient.Rodjak != null) //moze pacijent da nema rodjaka
                    lblCousin.Text = m.ClinicPatient.Rodjak.Ime + " " + m.ClinicPatient.Rodjak.Prezime + " " + m.ClinicPatient.Rodjak.Telefon;
                dgvMedicines.DataSource = m.PatientMedicines;
            }
        }
    }
}
