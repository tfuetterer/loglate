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
    public class InfoDelayedLoggingManagerTests
    {
        [TestMethod()]
        public void InfoMessageTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Info("Message");
            logManager.StoreLogs();
            mock.Verify(x => x.Info("Message"));
        }

        [TestMethod()]
        public void InfoMessageExceptionTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            Exception exception = new Exception();
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.Info("Message", exception);
            logManager.StoreLogs();
            mock.Verify(x => x.Info("Message", exception));
        }

        [TestMethod()]
        public void InfoFormatFormat1ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.InfoFormat("Format", "1");
            logManager.StoreLogs();
            mock.Verify(x => x.InfoFormat("Format", "1"));
        }

        [TestMethod()]
        public void InfoFormatFormat2ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.InfoFormat("Format", "1", "2");
            logManager.StoreLogs();
            mock.Verify(x => x.InfoFormat("Format", "1", "2"));
        }

        [TestMethod()]
        public void InfoFormatFormat3ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.InfoFormat("Format", "1", "2", "3");
            logManager.StoreLogs();
            mock.Verify(x => x.InfoFormat("Format", "1", "2", "3"));
        }

        [TestMethod()]
        public void InfoFormatFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.InfoFormat("Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.InfoFormat("Format", "1", "2", "3", "4"));
        }

        [TestMethod()]
        public void InfoProviderFormat4ArgTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager logManager = new DelayedLoggingManager(logger);
            logManager.InfoFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4");
            logManager.StoreLogs();
            mock.Verify(x => x.InfoFormat(Thread.CurrentThread.CurrentCulture, "Format", "1", "2", "3", "4"));
        }
    }
}