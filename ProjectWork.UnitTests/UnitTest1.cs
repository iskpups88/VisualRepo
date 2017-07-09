using System;
using NUnit.Framework;
using NHibernate;

namespace ProjectWork.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void does_session_open()
        {
            ISession session = NHibertnateSession.OpenSession();
            Assert.IsNotNull(session);
        }
    }
}
