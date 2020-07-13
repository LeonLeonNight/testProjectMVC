using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace testASPMVC.Models.DataAccessLayer
{
    public class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.PostgreSQL82
                        .ConnectionString(ConfigurationManager.ConnectionStrings["ConnectionString"]
                        .ConnectionString)
                        .ShowSql())
                        .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                        .ExposeConfiguration(conf => {
                            new SchemaUpdate(conf).Execute(false, true);
                            //new SchemaExport(conf).Execute(true, true, false)
                        })
                        .BuildSessionFactory();
                }
                return sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}