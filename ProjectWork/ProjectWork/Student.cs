using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork
{
    class Student
    {
        public virtual int id { get; protected set; }
        public virtual string FirstName { get; set;}
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string GroupNumber { get; set; }
        public virtual string Email{ get; set;}

        //public Student(string FirstName, string MiddleName, string LastName, string GroupNumber, string Email) {
        //    this.FirstName = FirstName;
        //    this.MiddleName = MiddleName;
        //    this.LastName = LastName;
        //    this.GroupNumber = GroupNumber;
        //    this.Email = Email;
        //}

        //public string getFirstName
        //{
        //    get { return FirstName; }
        //    set { FirstName = value; }
        //}

        //public string getMiddleName
        //{
        //    get { return MiddleName; }
        //    set { MiddleName = value; }
        //}

        //public string getLastName
        //{
        //    get { return LastName; }
        //    set { LastName = value; }
        //}

        //public string getGroupNumber
        //{
        //    get { return GroupNumber; }
        //    set { GroupNumber = value; }
        //}

        //public string getEmail
        //{
        //    get { return Email; }
        //    set { Email = value; }
        //}
    }
}
