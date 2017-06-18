using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Pomocne_forme
{
    public partial class DodavanjeLekaForm : MetroForm
    {
        DataTable lekovi = new DataTable("Lekovi");
        private int idLeka;
        private bool canceled = false;
        private DateTime datumDo;

        public DodavanjeLekaForm()
        {
            InitializeComponent();
            lekovi.Columns.Add("ID");
            lekovi.Columns.Add("Naziv");
            lekovi.Columns.Add("Opis");
            lekovi.Columns.Add("Nacin uzimanja");
            lekovi.Columns.Add("Tipicna doza");
            dtDatumDo.MinDate = DateTime.Today;
        }

        public int IdLeka { get { return this.idLeka; } }
        public bool Canceled { get { return this.canceled; } }
        public DateTime DatumDo { get { return this.datumDo; } }

        public void RefreshComponent()
        {
            dgvMedications.DataSource = lekovi;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lekovi.Rows.Clear();
            ISession s = DataLayer.GetSession();
            IList<PotrosniMaterijal> listaLekovi = s.QueryOver<PotrosniMaterijal>()
                .Where(c => c.TipMaterijala == "LEK" && c.Naziv.IsLike(tbSearchText.Text,MatchMode.Anywhere))
                .List();
            foreach (PotrosniMaterijal lek in listaLekovi)
            {
                lekovi.Rows.Add(lek.Id, lek.Naziv, lek.Opis, lek.NacinUzimanja, lek.TipicnaDoza);
            }
            s.Close();
            RefreshComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.canceled = true;
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            idLeka = Int32.Parse(dgvMedications.SelectedRows[0].Cells["ID"].Value.ToString());
            datumDo = dtDatumDo.Value;
            this.Hide();
        }        
    }
}
