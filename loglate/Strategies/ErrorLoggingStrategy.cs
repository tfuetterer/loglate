using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Strategies
{
    public class ErrorLoggingStrategy : ILoggingStrategy
    {
        ILog _logger;
        public ErrorLoggingStrategy(ILog logger)
        {
            _logger = logger;
        }
        public void Log(object message)
        {
            _logger.Error(message);
        }
        public void Log(object message, Exception exception)
        {
            _logger.Error(message, exception);
        }
        
        public void LogFormat(string format, List<object> argList)
        {
            switch(argList.Count)
            {
                case 1: _logger.ErrorFormat(format, argList[0]); break;
                case 2: _logger.ErrorFormat(format, argList[0], argList[1]); break;
                case 3: _logger.ErrorFormat(format, argList[0], argList[1], argList[2]); break;
                default: throw new ArgumentException("Too many arguments");
            }
        }
        public void LogFormat(string format, object[] args) {
            _logger.ErrorFormat(format, args);
        }
        public void LogFormat(IFormatProvider provider, string format, object[] args)
        {
            _logger.ErrorFormat(provider, format, args);
        }
    }
}
