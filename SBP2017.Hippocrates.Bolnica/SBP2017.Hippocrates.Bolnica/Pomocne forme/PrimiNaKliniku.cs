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
using SBP2017.Hippocrates.Bolnica.Data;
using MetroFramework;

namespace SBP2017.Hippocrates.Bolnica.Pomocne_forme
{
    public partial class PrimiNaKliniku : MetroForm
    {
        Zaposleni user;
        string ime, prezime, srodstvo, adresa, telefon, pol, adresapac, bstatus, borvak, krevet;
        string jmbg;
        bool nobeds = false;
        public bool canceled = false;
        public PrimiNaKliniku(Zaposleni user,String jmbg) : this()
        {
            this.user = user;
            this.jmbg = jmbg;
        }
        public PrimiNaKliniku(Zaposleni user, String jmbg,bool noVacantBeds):this()
        {
            this.user = user;
            this.jmbg = jmbg;
            nobeds = noVacantBeds;
        }
        public string Ime
        {
            get
            {
                return ime;
            }
        }
        public string Prezime
        {
            get
            {
                return prezime;
            }
        }
        public string Boravak
        {
            get
            {
                return borvak;
            }
        }
        public string BrojKreveta
        {
            get
            {
                return krevet;
            }
        }
        public bool Canceled
        {
            get
            {
                return canceled;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            canceled = true;
            this.Close();
        }

        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void txtPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void txtSrodstvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void txtPol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar)||txtPol.Text.Length==2)
                e.Handled = true;
        }

        private void txtBracniStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!nobeds)
                if (txtIme.Text == "" || txtPrezime.Text == "" || txtSrodstvo.Text == "" || txtAdresa.Text == "" || txtTelefon.Text == "" || txtAdresaPac.Text == "" || txtBracniStatus.Text == "" || txtBoravak.Text == "" || listBeds.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this, "Nesto nije lepo popunjeno", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            if (nobeds)
                if (txtIme.Text == "" || txtPrezime.Text == "" || txtSrodstvo.Text == "" || txtAdresa.Text == "" || txtTelefon.Text == "" || txtAdresaPac.Text == "" || txtBracniStatus.Text == "")
                {
                    MetroMessageBox.Show(this, "Nesto nije lepo popunjeno", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            ime = txtIme.Text;
            prezime = txtPrezime.Text;
            srodstvo = txtSrodstvo.Text;
            adresa = txtAdresa.Text;
            telefon = txtTelefon.Text;
            pol = txtPol.Text;
            adresapac = txtAdresaPac.Text;
            bstatus = txtBracniStatus.Text;
            borvak = txtBoravak.Text;
            if(!nobeds)
                krevet = listBeds.SelectedItems[0].ToString();
            this.Hide();
        }

        private void PrimiNaKliniku_Load(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            //popunjavanje textboxova
            PacijentKlinickogCentra pkc = s.QueryOver<PacijentKlinickogCentra>().Where(x => x.JMBG == jmbg).SingleOrDefault<PacijentKlinickogCentra>();
            if (pkc != null)
            {
                txtPol.Text = pkc.Pol;
                txtAdresaPac.Text = pkc.Adresa;
                txtBracniStatus.Text = pkc.BracniStatus;
                if (pkc.Rodjak != null)
                {
                    txtAdresa.Text = pkc.Rodjak.Adresa;
                    txtIme.Text = pkc.Rodjak.Ime;
                    txtPrezime.Text = pkc.Rodjak.Prezime;
                    txtTelefon.Text = pkc.Rodjak.Telefon;
                    txtSrodstvo.Text = pkc.Rodjak.Srodstvo;
                }
            }
            
            //slobodni kreveti
            s.Refresh(user);
            IList<Krevet> kreveti = s.QueryOver<Krevet>().Where(x => x.Klinika == user.Klinika).List<Krevet>();
            IList<BoraviNaKlinici> iskorisceno = s.QueryOver<BoraviNaKlinici>().Where(x => x.DatumOtpusta == null).List<BoraviNaKlinici>();
            IList<Krevet> slobodni = kreveti.ToList<Krevet>();
            foreach(BoraviNaKlinici bk in iskorisceno)
            {
                foreach(Krevet k in kreveti)
                {
                    if (k.Id == bk.BrojKreveta)
                        slobodni.Remove(k);
                }
            }
            foreach (Krevet kr in slobodni) 
            {
                listBeds.Items.Add(kr.Id.ToString());
            }
            s.Close();s.Dispose();
        }

        public string Srodstvo {
            get
            {
                return srodstvo;
            }
        }
        public string AdresaRodjak
        {
            get
            {
                return adresa;
            }
        }
        public string TelefonRodjak
        {
            get
            {
                return telefon;
            }
        }
        public string Pol
        {
            get
            {
                return pol;
            }
        }
        public string AdresaPacijent {
            get
            {
                return adresapac;
            }
        }
        public string BracniStatus
        {
            get
            {
                return bstatus;
            }
        }
        public PrimiNaKliniku()
        {
            InitializeComponent();
        }
    }
}
