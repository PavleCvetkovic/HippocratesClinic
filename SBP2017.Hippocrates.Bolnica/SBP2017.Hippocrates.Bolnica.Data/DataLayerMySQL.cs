using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
//*
//*
//*
//DEO ORM-A baze za domove zdravlja kako bi se izvrsila integracija, nije najsrecnije resenje, znam
//*
//*
//*
//*
namespace SBP2017.Hippocrates.Bolnica.Data
{
    public class DataLayerMySQL
    {
        private static ISessionFactory factory = null;
        private static object lockObj = new object();
        public static ISession GetSession()
        {
            if (factory == null)
            {
                lock (lockObj)
                {
                    if (factory == null)
                        factory = CreateSessionFactory();
                }
            }
            return factory.OpenSession();
        }
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = MySQLConfiguration.Standard.ConnectionString(c => c.Is("server=139.59.132.29;user=paja;charset=utf8;database=Hippocrates;port=3306;password=pajapro1234;"));
                return Fluently.Configure().Database(cfg.ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<MapiranjaMySql.DomZdravljaMapiranja>()).BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
