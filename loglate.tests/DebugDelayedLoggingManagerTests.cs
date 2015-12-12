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
    public class DebugDelayedLoggingManagerTests
    {
        [TestMethod()]
        public void DebugMessageTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Debug("Message");
            logManager.StoreLogs();
            mock.Verify(x => x.Debug("Message"));
        }

        [TestMethod()]
        public void DebugMessageExceptionTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            Exception exception = new Exception();
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Debug("Message", exception);
            logManager.StoreLogs();
            mock.Verify(x => x.Debug("Message", exception));
        }

        [TestMethod()]
        public void DebugFormatFormat1ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.DebugFormat("Format", "1");
            logManager.StoreLogs();
            mock.Verify(x => x.DebugFormat("Format", "1"));
        }

        [TestMethod()]
        public void DebugFormatFormat2ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.DebugFormat("Format", "1", "2");
            logManager.StoreLogs();
            mock.Verify(x => x.DebugFormat("Format", "1", "2"));
        }

        [TestMethod()]
        public void DebugFormatFormat3ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.DebugFormat("Format", "1", "2", "3");
            logManager.StoreLogs();
            mock.Verify(x => x.DebugFormat("Format", "1", "2", "3"));
        }

        [TestMethod()]
        public void DebugFormatFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.DebugFormat("Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.DebugFormat("Format", "1", "2", "3", "4"));
        }

        [TestMethod()]
        public void DebugProviderFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.DebugFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.DebugFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4"));
        }
    }
}