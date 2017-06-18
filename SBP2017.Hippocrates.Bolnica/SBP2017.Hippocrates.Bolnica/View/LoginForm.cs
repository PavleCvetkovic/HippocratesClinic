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
            Cursor.Current = Cursors.WaitCursor;
            bool success=(controller as LoginController).CheckLogin(Int32.Parse(txtUser.Text), txtPassword.Text);
            if (!success)
            {
                MetroMessageBox.Show(this, "NEISPRAVNA PRIJAVA", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var user=(controller as LoginController).returnUser();
                Type t = user.GetType();                
                if (t.Equals(typeof(Sestra))) //A switch expression or case label must be a bool, char, string, integral, enum, or corresponding nullable type
                {
                    if (user.Klinika.GlavnaSestraKlinike.Id==user.Id)
                    {
                        GlavnaSestraForm gsform = new GlavnaSestraForm();
                        IController gsctl = new GlavnaSestraController();
                        IModel gsmodel = new GlavnaSestraModel(user);
                        gsform.AttachToModel(gsmodel);
                        gsctl.AddModel(gsmodel);
                        gsform.AddControler(gsctl);
                        this.Hide();
                        Cursor.Current = Cursors.Default;
                        gsform.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        SestraBolnicar sbform = new SestraBolnicar();
                        IController sbctl = new SestraBolnicarController();
                        IModel sbmodel = new SestraBolnicarModel(user);
                        sbform.AttachToModel(sbmodel);
                        sbctl.AddModel(sbmodel);
                        sbform.AddControler(sbctl);
                        this.Hide();
                        Cursor.Current = Cursors.Default;
                        sbform.ShowDialog();
                        this.Show();
                    }
                }
                else if (t.Equals(typeof(Specijalista)))
                {
                    SpecijalistaForm specform = new SpecijalistaForm();
                    IController specctl = new SpecijalistaController();
                    IModel specmodel = new SpecijalistaModel(user as Specijalista);
                    specform.AttachToModel(specmodel);
                    specctl.AddModel(specmodel);
                    specform.AddControler(specctl);
                    this.Hide();
                    Cursor.Current = Cursors.Default;
                    specform.ShowDialog();
                    this.Show();
                }
                else if (t.Equals(typeof(Direktor)))
                {
                    DirektorForm dirform = new DirektorForm();
                    IController dirctl = new DirektorController();
                    IModel dirmodel = new DirektorModel(user as Direktor);
                    dirform.AttachToModel(dirmodel);
                    dirctl.AddModel(dirmodel);
                    dirform.AddControler(dirctl);
                    this.Hide();
                    Cursor.Current = Cursors.Default;
                    dirform.ShowDialog();                    
                    this.Show();
                }
            }
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }
    }
}
