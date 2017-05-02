using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using SBP2017.Hippocrates.Bolnica.Data;
using NHibernate;
using MetroFramework.Forms;
namespace SBP2017.Hippocrates.Bolnica
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            KlinickiCentar k = s.Load<KlinickiCentar>(1);
            IList<Klinika> klinike = new List<Klinika>();
            klinike = k.Klinike;
            foreach(Ugovor u in k.Ugovori)
            {
                MessageBox.Show(u.Zaposleni.Ime);
            }

            s.Close();
        }
    }
}
