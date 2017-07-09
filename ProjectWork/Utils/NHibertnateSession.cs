using NHibernate;
using NHibernate.Cfg;
using System.Data.SqlClient;


namespace ProjectWork
{
    public class NHibertnateSession
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
