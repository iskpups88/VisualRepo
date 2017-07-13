using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ProjectWork.Utils
{
    class XmlParser
    {
        public static List<Student> parse(string fileName)
        {
            List<Student> studentList;
            try
            {
                var doc = XDocument.Parse(File.ReadAllText(fileName));
                studentList = doc.Descendants("Student").Select(d => new Student
                {
                    FirstName = d.Element("FirstName").Value,
                    MiddleName = d.Element("MiddleName").Value,
                    LastName = d.Element("LastName").Value,
                    GroupNumber = d.Element("GroupNumber").Value,
                    Email = d.Element("Email").Value
                }).ToList();
                if(studentList.Count == 0)
                {
                    throw new XmlException();
                }
            }
            catch (XmlException e)
            {
                throw e;
            }
            return studentList;
        }
    }
}
