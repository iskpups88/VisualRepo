using System.Collections.Generic;

namespace ProjectWork.RepositoriesImpl
{
    interface IStudentRepo
    {
        void save(List<Student> studentList);

        IList<string> getGroup();

        IList<string> getEmail(string currentGroup);

        string getMiddleNameStudent(string name);
    }
}
