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
using NHibernate.Criterion;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Pomocne_forme
{
    public partial class DodajDobavljacaForm : MetroForm
    {
        private DataTable dobavljaci = new DataTable("Dobavljaci");
        private bool canceled = false;
        private int idDobavljaca;

        public bool Canceled { get { return this.canceled; } }
        public int IdDobavljaca { get { return this.idDobavljaca; } }

        public DodajDobavljacaForm()
        {
            InitializeComponent();
            dobavljaci.Columns.Add("ID");
            dobavljaci.Columns.Add("Naziv");
        }

        public void RefreshComponent()
        {
            dgvSuppliers.DataSource = dobavljaci;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dobavljaci.Rows.Clear();
            ISession s = DataLayer.GetSession();
            IList<Dobavljac> listaDobavljaci = s.QueryOver<Dobavljac>()
                .Where(c => c.Ime.IsLike(tbSearchText.Text, MatchMode.Anywhere))
                .List();
            foreach (Dobavljac dob in listaDobavljaci)
            {
                dobavljaci.Rows.Add(dob.Id, dob.Ime);
            }
            s.Close();
            RefreshComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            idDobavljaca = Int32.Parse(dgvSuppliers.SelectedRows[0].Cells["ID"].Value.ToString());
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.canceled = true;
            this.Hide();
        }
    }
}
