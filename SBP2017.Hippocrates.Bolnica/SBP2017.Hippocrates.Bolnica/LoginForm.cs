using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Components;
using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;

namespace SBP2017.Hippocrates.Bolnica
{
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Zaposleni as z where z.Id = ? and z.Password = ?");
            q.SetParameter(0, Int32.Parse(txtUser.Text));
            q.SetParameter(1, txtPassword.Text.ToString());
            IList<Zaposleni> employee = q.List<Zaposleni>();
            if (employee.Count == 1)
            {
                MetroMessageBox.Show(this, "USPESNA PRIJAVA", "prijava", MessageBoxButtons.OK);
            }
            else
            {
                MetroMessageBox.Show(this, "NEUSPESNA PRIJAVA", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
