using Microsoft.VisualStudio.TestTools.UnitTesting;
using loglate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using log4net;
using log4net.Core;

namespace loglate.tests
{
    [TestClass()]
    public class DelayedLoggingManagerTests
    {
        #region Debug
        [TestMethod()]
        public void IsDebugEnabledTrueTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsDebugEnabled).Returns(true);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(true, loggingManager.IsDebugEnabled);
        }

        [TestMethod()]
        public void IsDebugEnabledFalseTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsDebugEnabled).Returns(false);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(false, loggingManager.IsDebugEnabled);
        }
        #endregion

        #region Error
        [TestMethod()]
        public void IsErrorEnabledTrueTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsErrorEnabled).Returns(true);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(true, loggingManager.IsErrorEnabled);
        }

        [TestMethod()]
        public void IsErrorEnabledFalseTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsErrorEnabled).Returns(false);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(false, loggingManager.IsErrorEnabled);
        }
        #endregion

        #region Fatal
        [TestMethod()]
        public void IsFatalEnabledTrueTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsFatalEnabled).Returns(true);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(true, loggingManager.IsFatalEnabled);
        }

        [TestMethod()]
        public void IsFatalEnabledFalseTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsFatalEnabled).Returns(false);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(false, loggingManager.IsFatalEnabled);
        }
        #endregion

        #region Info
        [TestMethod()]
        public void IsInfoEnabledTrueTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsInfoEnabled).Returns(true);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(true, loggingManager.IsInfoEnabled);
        }

        [TestMethod()]
        public void IsInfoEnabledFalseTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsInfoEnabled).Returns(false);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(false, loggingManager.IsInfoEnabled);
        }
        #endregion

        #region Warn
        [TestMethod()]
        public void IsWarnEnabledTrueTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsWarnEnabled).Returns(true);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(true, loggingManager.IsWarnEnabled);
        }

        [TestMethod()]
        public void IsWarnEnabledFalseTest()
        {
            var mock = new Mock<ILog>();
            mock.Setup(x => x.IsWarnEnabled).Returns(false);
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            Assert.AreEqual(false, loggingManager.IsWarnEnabled);
        }
        #endregion

        [TestMethod()]
        public void StoreLogTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(logger);
            loggingManager.Debug("Message1");
            loggingManager.Debug("Message2");
            loggingManager.StoreLogs();

            mock.Verify(x => x.Debug("Message1"));
            mock.Verify(x => x.Debug("Message2"));

            loggingManager.Debug("Message3");
            loggingManager.StoreLogs();

            mock.Verify(x => x.Debug("Message1"), Times.Once);
            mock.Verify(x => x.Debug("Message2"), Times.Once);
            mock.Verify(x => x.Debug("Message3"));
        }

        [TestMethod()]
        public void GetLoggerTest()
        {
            var mockLogger = new Mock<ILogger>();
            ILogger logger = mockLogger.Object;

            var mockLog = new Mock<ILog>();
            mockLog.Setup(x => x.Logger).Returns(logger);

            ILog log = mockLog.Object;
            DelayedLoggingManager loggingManager = new DelayedLoggingManager(log);
            Assert.AreEqual(logger, loggingManager.Logger);
        }

    }
}