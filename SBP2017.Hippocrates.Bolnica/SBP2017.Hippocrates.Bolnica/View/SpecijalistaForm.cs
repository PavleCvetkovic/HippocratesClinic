﻿using System;
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

namespace SBP2017.Hippocrates.Bolnica.View
{
    public partial class SpecijalistaForm : MetroForm, IView
    {
        private IController controller;
        public SpecijalistaForm()
        {
            InitializeComponent();
        }

        public SpecijalistaForm(IController controller) : this()
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

        public new void Update() //to be done
        {
            throw new NotImplementedException();
        }
    }
}