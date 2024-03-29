﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBP2017.Hippocrates.Bolnica.View;
using SBP2017.Hippocrates.Bolnica.Data.Entiteti;
using NHibernate;
using SBP2017.Hippocrates.Bolnica.Data;

namespace SBP2017.Hippocrates.Bolnica.Model
{
    class LoginModel : IModel
    {
        Zaposleni user;
        public List<IView> views;


        public LoginModel()
        {
            views = new List<IView>();
        }
        public LoginModel(IView view)
            :this()
        {
            views.Add(view);
        }
        public void AddView(IView view)
        {
            views.Add(view);
        }

        public void UpdateViews()
        {
            foreach (IView v in views)
                v.Update();
        }
        public bool CheckLogin(int Id,string Password)
        {
            ISession s = DataLayer.GetSession();
            IQuery q = s.CreateQuery("from Zaposleni as z where z.Id = ? and z.Password = ?");
            q.SetParameter(0,Id);
            q.SetParameter(1, Password);
            IList<Zaposleni> employee = q.List<Zaposleni>();
            
            if (employee.Count == 1)
            {
                user = employee[0];
                NHibernateUtil.Initialize(user.Klinika.GlavnaSestraKlinike);
                s.Close(); s.Dispose();
                return true;
            }
            s.Close(); s.Dispose();
            return false;
        }
        public Zaposleni returnUser()
        {
                return user;
        }

        public void refreshData()
        {
            ISession s = DataLayer.GetSession();
            s.Refresh(user);
            s.Close();s.Dispose();
        }

        public bool searchPatientsByJMBG(string jmbg)
        {
            throw new NotImplementedException();
        }

        public bool searchPatientsByLBO(string lbo)
        {
            throw new NotImplementedException();
        }

        public bool searchPatientsByBedNo(string No)
        {
            throw new NotImplementedException();
        }
    }
}
