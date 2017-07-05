using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWork
{
    class NHibertnateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure();
            try
            {
                ISessionFactory sessionFactory = configuration.BuildSessionFactory();
                return sessionFactory.OpenSession();
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
