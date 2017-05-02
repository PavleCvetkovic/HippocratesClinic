using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace SBP2017.Hippocrates.Bolnica.Data
{
    public class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();


        //funkcija na zahtev otvara sesiju
        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {

            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S15058;Password=pajapro1234"));

                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SBP2017.Hippocrates.Bolnica.Data.Mapiranja.BoraviNaKliniciMapiranje>())
                    .BuildSessionFactory();
                
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
                return null;
            }

        }
    }
}
