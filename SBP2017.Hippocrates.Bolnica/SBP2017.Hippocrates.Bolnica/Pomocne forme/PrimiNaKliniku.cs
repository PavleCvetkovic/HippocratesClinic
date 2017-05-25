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

namespace SBP2017.Hippocrates.Bolnica.Pomocne_forme
{
    public partial class PrimiNaKliniku : MetroForm
    {
        Zaposleni user;
        string ime, prezime, srodstvo, adresa, telefon, pol, adresapac, bstatus, borvak, krevet;
        public PrimiNaKliniku(Zaposleni user) : this()
        {
            this.user = user;
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ime = txtIme.Text;
            prezime = txtPrezime.Text;
            srodstvo = txtSrodstvo.Text;
            adresa = txtAdresa.Text;
            telefon = txtTelefon.Text;
            pol = txtPol.Text;
            adresapac = txtAdresaPac.Text;
            bstatus = txtBracniStatus.Text;
            borvak = txtBoravak.Text;
            krevet = listBeds.SelectedItems[0].ToString();
            this.Close();
        }

        private void PrimiNaKliniku_Load(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
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
            s.Close();
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
