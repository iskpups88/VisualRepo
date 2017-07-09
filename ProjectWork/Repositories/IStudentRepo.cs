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

        object getGroup();

        object getEmail(string currentGroup);
    }
}
