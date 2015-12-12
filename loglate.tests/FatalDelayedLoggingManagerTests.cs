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
    public class FatalDelayedLoggingManagerTests
    {
        [TestMethod()]
        public void FatalMessageTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Fatal("Message");
            logManager.StoreLogs();
            mock.Verify(x => x.Fatal("Message"));
        }

        [TestMethod()]
        public void FatalMessageExceptionTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            Exception exception = new Exception();
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Fatal("Message", exception);
            logManager.StoreLogs();
            mock.Verify(x => x.Fatal("Message", exception));
        }

        [TestMethod()]
        public void FatalFormatFormat1ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.FatalFormat("Format", "1");
            logManager.StoreLogs();
            mock.Verify(x => x.FatalFormat("Format", "1"));
        }

        [TestMethod()]
        public void FatalFormatFormat2ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.FatalFormat("Format", "1", "2");
            logManager.StoreLogs();
            mock.Verify(x => x.FatalFormat("Format", "1", "2"));
        }

        [TestMethod()]
        public void FatalFormatFormat3ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.FatalFormat("Format", "1", "2", "3");
            logManager.StoreLogs();
            mock.Verify(x => x.FatalFormat("Format", "1", "2", "3"));
        }

        [TestMethod()]
        public void FatalFormatFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.FatalFormat("Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.FatalFormat("Format", "1", "2", "3", "4"));
        }

        [TestMethod()]
        public void FatalProviderFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.FatalFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.FatalFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4"));
        }
    }
}