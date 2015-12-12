using Microsoft.VisualStudio.TestTools.UnitTesting;
using loglate.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using log4net;
using System.Threading;

namespace loglate.Strategies.tests
{
    [TestClass()]
    public class WarnLoggingStrategyTests
    {
        string DefaultMessage = "message";
        string DefaultFormat = "format";

        [TestMethod()]
        public void LogMessageTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.Log(DefaultMessage);
            mock.Verify(x => x.Warn(DefaultMessage));
        }

        [TestMethod()]
        public void LogMessageExceptionTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            Exception exception = new Exception();
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.Log(DefaultMessage, exception);
            mock.Verify(x => x.Warn(DefaultMessage, exception));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LogFormatArgList0Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>();
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LogFormatArgList4Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { "1", "2", "3", "4" };
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
        }

        [TestMethod()]
        public void LogFormatArgList1Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { DefaultMessage };
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
            mock.Verify(x => x.WarnFormat(DefaultFormat, DefaultMessage));
        }

        [TestMethod()]
        public void LogFormatArgList2Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { "1", "2" };
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
            mock.Verify(x => x.WarnFormat(DefaultFormat, "1", "2"));
        }

        [TestMethod()]
        public void LogFormatArgList3Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { "1", "2", "3" };
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
            mock.Verify(x => x.WarnFormat(DefaultFormat, "1", "2", "3"));
        }

        [TestMethod()]
        public void LogFormatArgsTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            object[] args = new object[] { "1", "2", "3" };
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, args);
            mock.Verify(x => x.WarnFormat(DefaultFormat, args));
        }

        [TestMethod()]
        public void LogFormatArgsProviderTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            object[] args = new object[] { "1", "2", "3" };
            WarnLoggingStrategy strategy = new WarnLoggingStrategy(logger);
            strategy.LogFormat(Thread.CurrentThread.CurrentCulture, DefaultFormat, args);
            mock.Verify(x => x.WarnFormat(Thread.CurrentThread.CurrentCulture, DefaultFormat, args));
        }
    }
}