using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using System.IO;
using System.Xml.Linq;
using ProjectWork.RepositoriesImpl;

namespace ProjectWork.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void session_open()
        {
            ISession session = NHibertnateSession.OpenSession();
            Assert.IsNotNull(session, "session close");

        }

        [TestMethod]
        public void parser_is_working()
        {
            var doc = XDocument.Parse(File.ReadAllText("C:\\Users\\Искандер\\Desktop\\Students.xml"));
            Assert.IsNotNull(doc, "Cannot parse document");
        }

        [TestMethod]
        public void quantyty_of_students()
        {
            StudentRepo studRep = new StudentRepo();
            int n = studRep.getQuantityOfStud("11-503");
            Assert.AreEqual(n, 5);
        }

        [TestMethod]
        public void check_middle_name()
        {
            StudentRepo studRep = new StudentRepo();
            string n = studRep.getMiddleNameStudent("Искандер");
            Assert.AreEqual(n,"Хакимжанов");
        }

    }
}
