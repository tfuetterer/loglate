using Microsoft.VisualStudio.TestTools.UnitTesting;
using loglate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using log4net;
using System.Threading;

namespace loglate.tests
{
    [TestClass()]
    public class ErrorDelayedLoggingManagerTests
    {
        [TestMethod()]
        public void ErrorMessageTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Error("Message");
            logManager.StoreLogs();
            mock.Verify(x => x.Error("Message"));
        }

        [TestMethod()]
        public void ErrorMessageExceptionTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            Exception exception = new Exception();
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Error("Message", exception);
            logManager.StoreLogs();
            mock.Verify(x => x.Error("Message", exception));
        }

        [TestMethod()]
        public void ErrorFormatFormat1ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.ErrorFormat("Format", "1");
            logManager.StoreLogs();
            mock.Verify(x => x.ErrorFormat("Format", "1"));
        }

        [TestMethod()]
        public void ErrorFormatFormat2ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.ErrorFormat("Format", "1", "2");
            logManager.StoreLogs();
            mock.Verify(x => x.ErrorFormat("Format", "1", "2"));
        }

        [TestMethod()]
        public void ErrorFormatFormat3ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.ErrorFormat("Format", "1", "2", "3");
            logManager.StoreLogs();
            mock.Verify(x => x.ErrorFormat("Format", "1", "2", "3"));
        }

        [TestMethod()]
        public void ErrorFormatFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.ErrorFormat("Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.ErrorFormat("Format", "1", "2", "3", "4"));
        }

        [TestMethod()]
        public void ErrorProviderFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.ErrorFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.ErrorFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4"));
        }
    }
}