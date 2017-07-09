using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace ProjectWork.RepositoriesImpl
{
   class StudentRepo : IStudentRepo
    {
        static private ISession session;    

        public void save(List<Student> StudentList)
        {
            session = NHibertnateSession.OpenSession();

            var query1 = session.QueryOver<Student>()
              .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.Email)))
              )
              .List<object>();

            foreach (Student st in StudentList)
            {
                if (!query1.Contains(st.Email))
                    session.Save(st);

            }
            session.Close();
        }
       
        public object getGroup()
        {
            session = NHibertnateSession.OpenSession();
            var query = session.QueryOver<Student>()
                     .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.GroupNumber)))
                     )
                     .List<object>();


            //ICriteria criteria = sess ion.CreateCriteria(typeof(Student));
            //criteria.SetProjection(
            //        Projections.Distinct(Projections.ProjectionList()
            //            .Add(Projections.Alias(Projections.Property("GroupNumber"), "GroupNumber"))
            //               ))
            //               .SetResultTransformer(
            //        new NHibernate.Transform.AliasToBeanResultTransformer(typeof(Student)));
            //IList<Student> listgr = criteria.List<Student>();

            session.Close();
            return query;
        }

        public object getEmail(string currentGroup)
        {
            session = NHibertnateSession.OpenSession();
            var query = session.QueryOver<Student>()
                 .Where(p => p.GroupNumber == currentGroup)
                 .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.Email)))
                 )
                 .List<object>();
            session.Close();
            return query;
        }
    }
}
