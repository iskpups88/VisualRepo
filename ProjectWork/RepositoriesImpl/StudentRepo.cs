using NHibernate;
using NHibernate.Criterion;
using NLog;
using System.Collections.Generic;

namespace ProjectWork.RepositoriesImpl
{
   public class StudentRepo : IStudentRepo
    {
        static private ISession session;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public void save(List<Student> studentList)
        {
            session = NHibertnateSession.OpenSession();

            var query = session.QueryOver<Student>()
              .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.Email)))
              )
              .List<object>();

            foreach (Student st in studentList)
            {
                if (!query.Contains(st.Email))
                    session.Save(st);

            }
            logger.Info("insert to database '" + studentList.Count + "' rows");
            session.Close();
        }
       
        public IList<string> getGroup()
        {
            session = NHibertnateSession.OpenSession();
            var query = session.QueryOver<Student>()
                     .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.GroupNumber)))
                     )
                     .List<object>();

            IList<string> groupList = new List<string>();
            foreach (var item in query)
            {
                groupList.Add(item.ToString());
            }


            //ICriteria criteria = session.CreateCriteria(typeof(Student));
            //criteria.SetProjection(
            //        Projections.Distinct(Projections.ProjectionList()
            //            .Add(Projections.Alias(Projections.Property("GroupNumber"), "GroupNumber"))
            //               ))
            //               .SetResultTransformer(
            //        new NHibernate.Transform.AliasToBeanResultTransformer(typeof(Student)));
            //IList<Student> listgr = criteria.List<Student>();

            session.Close();
            return groupList;
        }

        public IList<string> getEmail(string currentGroup)
        {
            session = NHibertnateSession.OpenSession();
            var query = session.QueryOver<Student>()
                 .Where(p => p.GroupNumber == currentGroup)
                 .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.Email)))
                 )
                 .List<object>();

            session.Close();
            IList<string> emailList = new List<string>();
            foreach (var item in query)
            {
                emailList.Add(item.ToString());
            }
            return emailList;
        }

        public int getQuantityOfStud(string currentGroup)
        {
            session = NHibertnateSession.OpenSession();
            int n = session.QueryOver<Student>()
                 .Where(p => p.GroupNumber == currentGroup)
                 .RowCount();

            session.Close();            
            return n;
        }

        public string getMiddleNameStudent(string name)
        {
            session = NHibertnateSession.OpenSession();
            var query = session.QueryOver<Student>()
                             .Where(p => p.FirstName == name)
                             .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.LastName)))
                             )
                             .List<object>();

            string lastName = query[0].ToString();
            session.Close();
            return lastName;
        }
    }
}
