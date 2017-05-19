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

        }

        private void SestraBolnicar_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void TabPagePatienstOnClinic_Enter(object sender, EventArgs e)
        {
            (controller as SestraBolnicarController).patientsAtClinic();
            DataSet ds = new DataSet("patients");
            DataTable patinets = new DataTable("patients");
            patinets.Columns.Add("Name");
            patinets.Columns.Add("Datum");
            patinets.Columns.Add("Ime");
            foreach (BoraviNaKlinici b in(controller.getModel() as SestraBolnicarModel).User.Klinika.Pacijenti)
            {
                patinets.Rows.Add(b.Id, b.DatumPrijema,b.Pacijent.Ime);
            }
            dgvPatients.DataSource = patinets;
        }

        private void TabPageQueue_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
