using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
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
                new SchemaUpdate(configuration).Execute(true, true);
                return sessionFactory.OpenSession();
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
