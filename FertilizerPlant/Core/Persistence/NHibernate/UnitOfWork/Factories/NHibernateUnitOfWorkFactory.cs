﻿using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.Generic.UnitOfWork.Factories;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.Persistence.NHibernate.UnitOfWork.Factories
{
    /// <summary>
    ///UnitOfWork Factory is maintained by UnitOfWork Class
    /// </summary>
    public class NHibernateUnitOfWorkFactory:IUnitOfWorkFactory
    {
        private static string DEFAULT_HIBERNATE_CONFIG = "hibernate.cfg.xml";
        private Configuration configuration;
        private ISessionFactory sessionFactory;

        internal NHibernateUnitOfWorkFactory()
        {

        }
        private ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }
        public IUnitOfWork Create()
        {
            ISession session = CreateSession();
            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork(this, session);
            unitOfWork.BeginTransaction();
            return unitOfWork;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if(sessionFactory == null)
                {
                    sessionFactory = Configuration.BuildSessionFactory();
                }
                return sessionFactory;
            }
        }
        public Configuration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new Configuration();
                    string hibernateConfig = DEFAULT_HIBERNATE_CONFIG;
                    if (Path.IsPathRooted(hibernateConfig) == false)
                    {
                        hibernateConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hibernateConfig
                            );

                    }
                    if (File.Exists(hibernateConfig))
                    {
                        configuration.Configure(new XmlTextReader(hibernateConfig));
                    }
                }
                return configuration;
            }
        }
    }
    
}
