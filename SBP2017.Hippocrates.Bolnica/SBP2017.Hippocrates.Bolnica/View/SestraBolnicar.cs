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
using SBP2017.Hippocrates.Bolnica.Controller;
using SBP2017.Hippocrates.Bolnica.Model;
using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data;
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
            controller.refreshData();

            lblUserName.Text = (controller.getModel() as SestraBolnicarModel).User.Ime +" "+ (controller.getModel() as SestraBolnicarModel).User.Prezime;
            dgvPatients.DataSource = (controller as SestraBolnicarController).patientsAtClinic();
            dgvQueue.DataSource = (controller as SestraBolnicarController).patientsAtQueue();
            lblAdressClinic.Text = (controller.getModel() as SestraBolnicarModel).User.Klinika.Lokacija.ToString();
            lblCCName.Text = (controller.getModel() as SestraBolnicarModel).User.Klinika.KlinickiCentar.Ime.ToString();
            lblClinicName.Text = (controller.getModel() as SestraBolnicarModel).User.Klinika.Naziv;
            lblCSName.Text = (controller.getModel() as SestraBolnicarModel).User.Klinika.GlavnaSestraKlinike.Ime + " " + (controller.getModel() as SestraBolnicarModel).User.Klinika.GlavnaSestraKlinike.Prezime;
            lblVacantBeds.Text = (controller as SestraBolnicarController).vacantBeds().ToString();
        }

        private void SestraBolnicar_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void TabPagePatienstOnClinic_Enter(object sender, EventArgs e)
        {
            dgvPatients.DataSource = (controller as SestraBolnicarController).patientsAtClinic();
        }

        private void TabPageQueue_Enter(object sender, EventArgs e)
        {
            dgvQueue.DataSource = (controller as SestraBolnicarController).patientsAtQueue();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            (controller as SestraBolnicarController).searchPatientsByJMBG("0110970112870");
        }
    }
}
