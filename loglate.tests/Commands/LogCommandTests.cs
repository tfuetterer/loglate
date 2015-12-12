using Microsoft.VisualStudio.TestTools.UnitTesting;
using loglate.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using loglate.Strategies;
using System.Threading;

namespace loglate.Commands.tests
{
    [TestClass()]
    public class LogCommandTests
    {
        [TestMethod()]
        public void PerfomLogMessageTest()
        {
            var mock = new Mock<ILoggingStrategy>();
            LogCommand command = new LogCommand("Message", mock.Object);
            command.PerfomLog();
            mock.Verify(x => x.Log("Message"));
        }

        [TestMethod()]
        public void PerfomLogMessageExceptionTest()
        {
            var mock = new Mock<ILoggingStrategy>();
            Exception exception = new Exception();
            LogCommand command = new LogCommand("Message", exception, mock.Object);
            command.PerfomLog();
            mock.Verify(x => x.Log("Message", exception));
        }

        [TestMethod()]
        public void PerfomLogFormatArgsListTest()
        {
            var mock = new Mock<ILoggingStrategy>();
            List<object> argList = new List<object>();
            LogCommand command = new LogCommand("Format", argList, mock.Object);
            command.PerfomLog();
            mock.Verify(x => x.LogFormat("Format", argList));
        }

        [TestMethod()]
        public void PerfomLogFormatArgsTest()
        {
            var mock = new Mock<ILoggingStrategy>();
            object[] args = new object[1];
            LogCommand command = new LogCommand("Format", args, mock.Object);
            command.PerfomLog();
            mock.Verify(x => x.LogFormat("Format", args));
        }

        [TestMethod()]
        public void PerfomLogFormatArgsProviderTest()
        {
            var mock = new Mock<ILoggingStrategy>();
            object[] args = new object[1];
            LogCommand command = new LogCommand(Thread.CurrentThread.CurrentCulture, "Format", args, mock.Object);
            command.PerfomLog();
            mock.Verify(x => x.LogFormat(Thread.CurrentThread.CurrentCulture,"Format", args));
        }
    }
}