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
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica.Pomocne_forme
{
    public partial class DodajZaposlenogForm : MetroForm
    {
        private Zaposleni user;      
        private DataTable ugovori;
        private DataTable klinike;
        private bool canceled = false;
        private Zaposleni NoviZaposleni;
        private string tip, tipSestre;


        public bool Canceled { get { return this.canceled; } }

        public DodajZaposlenogForm(Zaposleni user)
        {
            InitializeComponent();
            this.user = user;
            dtBirthDate.MaxDate = new DateTime(2000,1,1);            
            klinike = new DataTable("Klinike");
            klinike.Columns.Add("ID");
            klinike.Columns.Add("Naziv");
            ugovori = new DataTable("Ugovori");
            ugovori.Columns.Add("ID");
            ugovori.Columns.Add("Broj sati nedeljno");
            ugovori.Columns.Add("Tip isplate");
            ugovori.Columns.Add("Tip ugovora");

            ISession s = DataLayer.GetSession();
            foreach (Klinika klinika in user.Klinika.KlinickiCentar.Klinike)
            {
                klinike.Rows.Add(klinika.Id, klinika.Naziv);
            }
            s.Close();
            dgvKlinike.DataSource = klinike;

        }

        public void refreshData()
        {
            dgvUgovori.DataSource = ugovori;
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void tbxSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void tbxJMBG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            switch (tip)
            {
                case "SESTRA":
                    NoviZaposleni = new Sestra()
                    {
                        Ime = tbxName.Text,
                        Prezime = tbxSurname.Text,
                        Adresa = tbxAddress.Text,
                        Telefon = tbxTelephone.Text,
                        Pol = tbxGender.Text,
                        DatumRodjenja = dtBirthDate.Value,
                        JMBG = tbxJMBG.Text,
                        TipSestre = tipSestre,
                        Ugovor = s.Load<Ugovor>(Int32.Parse(dgvUgovori.SelectedRows[0].Cells["ID"].Value.ToString())),
                        Klinika = s.Load<Klinika>(Int32.Parse(dgvKlinike.SelectedRows[0].Cells["ID"].Value.ToString())),
                        Password = tbxPassword.Text
                    };                   
                    break;

                case "SPECIJALISTA":
                    NoviZaposleni = new Specijalista()
                    {      
                        Ime = tbxName.Text,
                        Prezime = tbxSurname.Text,
                        Adresa = tbxAddress.Text,
                        Telefon = tbxTelephone.Text,
                        Pol = tbxGender.Text,
                        DatumRodjenja = dtBirthDate.Value,
                        JMBG = tbxJMBG.Text,                        
                        Ugovor = s.Load<Ugovor>(Int32.Parse(dgvUgovori.SelectedRows[0].Cells["ID"].Value.ToString())),
                        Klinika = s.Load<Klinika>(Int32.Parse(dgvKlinike.SelectedRows[0].Cells["ID"].Value.ToString())),
                        Password = tbxPassword.Text,
                        BrojOrdinacije = tbxRoomNo.Text
                        
                    };
                    break;
            }
            s.Save(NoviZaposleni);
            s.Close();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.canceled = true;
            this.Close();
        }

        private void tbxGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            string slovo = e.KeyChar.ToString();
            if (slovo.Equals("M") || slovo.Equals("Z"))
                e.Handled = false;
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
        }

        private void rbtn_Click(object sender, EventArgs e)
        {
            ugovori.Rows.Clear();
            ISession s = DataLayer.GetSession();
            IList<Ugovor> listaUgovora = null;
            if (rbtnSestraMladja.Checked)
            {
                listaUgovora = s.QueryOver<Ugovor>()
                    .Where(x => x.Pozicija == "MLADJA SESTRA" && x.KlinickiCentar == user.Klinika.KlinickiCentar)
                    .List<Ugovor>();
                tip = "SESTRA";
                tipSestre = "MLADJA";
            }
            else if (rbtnSestraStarija.Checked)
            {
                listaUgovora = s.QueryOver<Ugovor>()
                    .Where(x => x.Pozicija == "STARIJA SESTRA" && x.KlinickiCentar == user.Klinika.KlinickiCentar)
                    .List<Ugovor>();
                tip = "SESTRA";
                tipSestre = "STARIJA";
            }
            else if(rbtnSpecijalista.Checked)
            {
                listaUgovora = s.QueryOver<Ugovor>()
                    .Where(x => x.Pozicija == "SPECIJALISTA" && x.KlinickiCentar == user.Klinika.KlinickiCentar)
                    .List<Ugovor>();
                tip = "SPECIJALISTA";
            }
            foreach (Ugovor ugovor in listaUgovora)
            {
                ugovori.Rows.Add(ugovor.Id, ugovor.BrojSatiNedeljno, ugovor.TipIsplate, ugovor.TipUgovora);
            }
            s.Close();
            refreshData();
        }
    }
}
