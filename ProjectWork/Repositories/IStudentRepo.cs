using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.RepositoriesImpl
{
    interface IStudentRepo
    {
        void save(List<Student> studentList);

        IList<string> getGroup();

        IList<string> getEmail(string currentGroup);
    }
}
