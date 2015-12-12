using Microsoft.VisualStudio.TestTools.UnitTesting;
using loglate.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Moq;

namespace loglate.Factories.tests
{
    [TestClass()]
    public class LoggingManagerFactoryTests
    {
        [TestMethod()]
        public void GetLoggingManagerTest()
        {
            var mock = new Mock<ILog>();
            ILog loggingManager = LoggingManagerFactory.GetLoggingManager(mock.Object);
            Assert.IsInstanceOfType(loggingManager, typeof(DelayedLoggingManager));
        }
    }
}