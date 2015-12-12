using Microsoft.VisualStudio.TestTools.UnitTesting;
using loglate.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using loglate.Enums;
using Moq;
using log4net;
using loglate.Strategies;

namespace loglate.Factories.tests
{
    [TestClass()]
    public class LoggingStrategyFactoryTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStrategyNoLogLevelTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            ILoggingStrategy strategy = 
                LoggingStrategyFactory.GetStrategy(LogLevel.Debug, null);
            Assert.IsInstanceOfType(strategy, typeof(DebugLoggingStrategy));
        }

        [TestMethod()]
        public void GetStrategyDebugTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            ILoggingStrategy strategy = 
                LoggingStrategyFactory.GetStrategy(LogLevel.Debug, logger);
            Assert.IsInstanceOfType(strategy, typeof(DebugLoggingStrategy));
        }

        [TestMethod()]
        public void GetStrategyErrorTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            ILoggingStrategy strategy =
                LoggingStrategyFactory.GetStrategy(LogLevel.Error, logger);
            Assert.IsInstanceOfType(strategy, typeof(ErrorLoggingStrategy));
        }

        [TestMethod()]
        public void GetStrategyFatalTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            ILoggingStrategy strategy =
                LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, logger);
            Assert.IsInstanceOfType(strategy, typeof(FatalLoggingStrategy));
        }

        [TestMethod()]
        public void GetStrategyInfoTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            ILoggingStrategy strategy =
                LoggingStrategyFactory.GetStrategy(LogLevel.Info, logger);
            Assert.IsInstanceOfType(strategy, typeof(InfoLoggingStrategy));
        }

        [TestMethod()]
        public void GetStrategyWarnTest()
        {
            var mock = new Mock<ILog>();
            ILog logger = mock.Object;
            ILoggingStrategy strategy =
                LoggingStrategyFactory.GetStrategy(LogLevel.Warn, logger);
            Assert.IsInstanceOfType(strategy, typeof(WarnLoggingStrategy));
        }
    }
}