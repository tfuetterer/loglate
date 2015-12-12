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
    public class DebugLoggingStrategyTests
    {
        string DefaultMessage = "message";
        string DefaultFormat = "format";

        [TestMethod()]
        public void LogMessageTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.Log(DefaultMessage);
            mock.Verify(x => x.Debug(DefaultMessage));
        }

        [TestMethod()]
        public void LogMessageExceptionTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            Exception exception = new Exception();
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.Log(DefaultMessage, exception);
            mock.Verify(x => x.Debug(DefaultMessage, exception));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LogFormatArgList0Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>();
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LogFormatArgList4Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { "1", "2", "3", "4" };
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
        }

        [TestMethod()]
        public void LogFormatArgList1Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { DefaultMessage };
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
            mock.Verify(x => x.DebugFormat(DefaultFormat, DefaultMessage));
        }

        [TestMethod()]
        public void LogFormatArgList2Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { "1", "2" };
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
            mock.Verify(x => x.DebugFormat(DefaultFormat, "1", "2"));
        }

        [TestMethod()]
        public void LogFormatArgList3Test()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            List<object> argList = new List<object>() { "1", "2", "3" };
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, argList);
            mock.Verify(x => x.DebugFormat(DefaultFormat, "1", "2", "3"));
        }

        [TestMethod()]
        public void LogFormatArgsTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            object[] args = new object[] { "1", "2", "3" };
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.LogFormat(DefaultFormat, args);
            mock.Verify(x => x.DebugFormat(DefaultFormat, args));
        }

        [TestMethod()]
        public void LogFormatArgsProviderTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            object[] args = new object[] { "1", "2", "3" };
            DebugLoggingStrategy strategy = new DebugLoggingStrategy(logger);
            strategy.LogFormat(Thread.CurrentThread.CurrentCulture, DefaultFormat, args);
            mock.Verify(x => x.DebugFormat(Thread.CurrentThread.CurrentCulture, DefaultFormat, args));
        }
    }
}