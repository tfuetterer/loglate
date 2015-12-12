using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using loglate.Commands;
using loglate.Strategies;
using loglate.Factories;
using loglate.Enums;

namespace loglate
{
    public class DelayedLoggingManager : ILog
    {
        #region Fields
        private ILog _logger;
        private List<ILogCommand> _commands;
        #endregion

        public DelayedLoggingManager(ILog logger)
        {
            _logger = logger;
            _commands = new List<ILogCommand>();
        }

        #region Properties
        public bool IsDebugEnabled
        {
            get
            {
                return _logger.IsDebugEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return _logger.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return _logger.IsFatalEnabled;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return _logger.IsInfoEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return _logger.IsWarnEnabled;
            }
        }

        public ILogger Logger
        {
            get
            {
                return _logger.Logger;
            }
        } 
        #endregion

        public void StoreLogs()
        {
            _commands.ForEach(x => x.PerfomLog());
            _commands.Clear();
        }

        public void Debug(object message)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Debug, _logger);
            LogCommand command = new LogCommand(message, strategy);
            _commands.Add(command);
        }

        public void Debug(object message, Exception exception)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Debug, _logger);
            LogCommand command = new LogCommand(message, exception, strategy);
            _commands.Add(command);
        }

        public void DebugFormat(string format, object arg0)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Debug, _logger);
            List<object> argList = new List<object>() { arg0 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void DebugFormat(string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Debug, _logger);
            LogCommand command = new LogCommand(format, args, strategy);
            _commands.Add(command);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Debug, _logger);
            LogCommand command = new LogCommand(provider, format, args, strategy);
            _commands.Add(command);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Debug, _logger);
            List<object> argList = new List<object>() { arg0, arg1 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Debug, _logger);
            List<object> argList = new List<object>() { arg0, arg1, arg2 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void Error(object message)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Error, _logger);
            LogCommand command = new LogCommand(message, strategy);
            _commands.Add(command);
        }

        public void Error(object message, Exception exception)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Error, _logger);
            LogCommand command = new LogCommand(message, exception, strategy);
            _commands.Add(command);
        }

        public void ErrorFormat(string format, object arg0)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Error, _logger);
            List<object> argList = new List<object>() { arg0 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Error, _logger);
            LogCommand command = new LogCommand(format, args, strategy);
            _commands.Add(command);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Error, _logger);
            LogCommand command = new LogCommand(provider, format, args, strategy);
            _commands.Add(command);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Error, _logger);
            List<object> argList = new List<object>() { arg0, arg1 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Error, _logger);
            List<object> argList = new List<object>() { arg0, arg1, arg2 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void Fatal(object message)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, _logger);
            LogCommand command = new LogCommand(message, strategy);
            _commands.Add(command);
        }

        public void Fatal(object message, Exception exception)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, _logger);
            LogCommand command = new LogCommand(message, exception, strategy);
            _commands.Add(command);
        }

        public void FatalFormat(string format, object arg0)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, _logger);
            List<object> argList = new List<object>() { arg0 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void FatalFormat(string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, _logger);
            LogCommand command = new LogCommand(format, args, strategy);
            _commands.Add(command);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, _logger);
            LogCommand command = new LogCommand(provider, format, args, strategy);
            _commands.Add(command);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, _logger);
            List<object> argList = new List<object>() { arg0, arg1 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Fatal, _logger);
            List<object> argList = new List<object>() { arg0, arg1, arg2 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void Info(object message)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Info, _logger);
            LogCommand command = new LogCommand(message, strategy);
            _commands.Add(command);
        }

        public void Info(object message, Exception exception)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Info, _logger);
            LogCommand command = new LogCommand(message, exception, strategy);
            _commands.Add(command);
        }

        public void InfoFormat(string format, object arg0)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Info, _logger);
            List<object> argList = new List<object>() { arg0 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void InfoFormat(string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Info, _logger);
            LogCommand command = new LogCommand(format, args, strategy);
            _commands.Add(command);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Info, _logger);
            LogCommand command = new LogCommand(provider, format, args, strategy);
            _commands.Add(command);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Info, _logger);
            List<object> argList = new List<object>() { arg0, arg1 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Info, _logger);
            List<object> argList = new List<object>() { arg0, arg1, arg2 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void Warn(object message)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Warn, _logger);
            LogCommand command = new LogCommand(message, strategy);
            _commands.Add(command);
        }

        public void Warn(object message, Exception exception)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Warn, _logger);
            LogCommand command = new LogCommand(message, exception, strategy);
            _commands.Add(command);
        }

        public void WarnFormat(string format, object arg0)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Warn, _logger);
            List<object> argList = new List<object>() { arg0 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void WarnFormat(string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Warn, _logger);
            LogCommand command = new LogCommand(format, args, strategy);
            _commands.Add(command);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Warn, _logger);
            LogCommand command = new LogCommand(provider, format, args, strategy);
            _commands.Add(command);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Warn, _logger);
            List<object> argList = new List<object>() { arg0, arg1 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            ILoggingStrategy strategy = LoggingStrategyFactory.GetStrategy(LogLevel.Warn, _logger);
            List<object> argList = new List<object>() { arg0, arg1, arg2 };
            LogCommand command = new LogCommand(format, argList, strategy);
            _commands.Add(command);
        }
    }
}
