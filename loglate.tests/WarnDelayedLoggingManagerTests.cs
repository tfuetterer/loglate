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
    public class WarnDelayedLoggingManagerTests
    {
        [TestMethod()]
        public void WarnMessageTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Warn("Message");
            logManager.StoreLogs();
            mock.Verify(x => x.Warn("Message"));
        }

        [TestMethod()]
        public void WarnMessageExceptionTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            Exception exception = new Exception();
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Warn("Message", exception);
            logManager.StoreLogs();
            mock.Verify(x => x.Warn("Message", exception));
        }

        [TestMethod()]
        public void WarnFormatFormat1ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.WarnFormat("Format", "1");
            logManager.StoreLogs();
            mock.Verify(x => x.WarnFormat("Format", "1"));
        }

        [TestMethod()]
        public void WarnFormatFormat2ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.WarnFormat("Format", "1", "2");
            logManager.StoreLogs();
            mock.Verify(x => x.WarnFormat("Format", "1", "2"));
        }

        [TestMethod()]
        public void WarnFormatFormat3ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.WarnFormat("Format", "1", "2", "3");
            logManager.StoreLogs();
            mock.Verify(x => x.WarnFormat("Format", "1", "2", "3"));
        }

        [TestMethod()]
        public void WarnFormatFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.WarnFormat("Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.WarnFormat("Format", "1", "2", "3", "4"));
        }

        [TestMethod()]
        public void WarnProviderFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.WarnFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.WarnFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4"));
        }
    }
}