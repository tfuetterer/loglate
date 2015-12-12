using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Strategies
{
    public class DebugLoggingStrategy : ILoggingStrategy
    {
        ILog _logger;
        public DebugLoggingStrategy(ILog logger)
        {
            _logger = logger;
        }
        public void Log(object message)
        {
            _logger.Debug(message);
        }
        public void Log(object message, Exception exception)
        {
            _logger.Debug(message, exception);
        }
        
        public void LogFormat(string format, List<object> argList)
        {
            switch(argList.Count)
            {
                case 1: _logger.DebugFormat(format, argList[0]); break;
                case 2: _logger.DebugFormat(format, argList[0], argList[1]); break;
                case 3: _logger.DebugFormat(format, argList[0], argList[1], argList[2]); break;
                default: throw new ArgumentException("Too many arguments");
            }
        }
        public void LogFormat(string format, object[] args) {
            _logger.DebugFormat(format, args);
        }
        public void LogFormat(IFormatProvider provider, string format, object[] args)
        {
            _logger.DebugFormat(provider, format, args);
        }
    }
}
