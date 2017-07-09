using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using System.IO;
using System.Xml.Linq;

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
    }
}
