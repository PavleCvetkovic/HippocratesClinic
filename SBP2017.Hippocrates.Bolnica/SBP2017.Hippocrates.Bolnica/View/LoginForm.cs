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
using SBP2017.Hippocrates.Bolnica.Controller;
using SBP2017.Hippocrates.Bolnica.Model;

namespace SBP2017.Hippocrates.Bolnica.View
{
    public partial class LoginForm : MetroForm,IView
    {
        private IController controller;

        public LoginForm()
        {
            InitializeComponent();
        }
        public LoginForm(IController controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        public void AddControler(IController controller)
        {
            this.controller = controller;
        }

        public void AttachToModel(IModel model)
        {
            model.AddView(this);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool success=(controller as LoginController).CheckLogin(Int32.Parse(txtUser.Text), txtPassword.Text);
            if (!success)
            {
                MetroMessageBox.Show(this, "NEISPRAVNA PRIJAVA", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var user=(controller as LoginController).returnUser();
                Type t = user.GetType();
                if (t.Equals(typeof(Sestra)))
                {
                        SestraBolnicar sbform = new SestraBolnicar();
                        IController sbctl = new SestraBolnicarController();
                        IModel sbmodel = new SestraBolnicarModel(user);
                        sbform.AttachToModel(sbmodel);
                        sbctl.AddModel(sbmodel);
                        sbmodel.AddView(sbform);
                        this.Hide();
                        sbform.Show();
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
