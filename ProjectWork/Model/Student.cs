﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork
{
    public class Student
    {
        public virtual int id { get; protected set; }
        public virtual string FirstName { get; set;}
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string GroupNumber { get; set; }
        public virtual string Email{ get; set;} 
    }
}
