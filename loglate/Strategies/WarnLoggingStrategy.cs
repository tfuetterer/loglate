using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Strategies
{
    public class WarnLoggingStrategy : ILoggingStrategy
    {
        ILog _logger;
        public WarnLoggingStrategy(ILog logger)
        {
            _logger = logger;
        }
        public void Log(object message)
        {
            _logger.Warn(message);
        }
        public void Log(object message, Exception exception)
        {
            _logger.Warn(message, exception);
        }
        
        public void LogFormat(string format, List<object> argList)
        {
            switch(argList.Count)
            {
                case 1: _logger.WarnFormat(format, argList[0]); break;
                case 2: _logger.WarnFormat(format, argList[0], argList[1]); break;
                case 3: _logger.WarnFormat(format, argList[0], argList[1], argList[2]); break;
                default: throw new ArgumentException("Too many arguments");
            }
        }
        public void LogFormat(string format, object[] args) {
            _logger.WarnFormat(format, args);
        }
        public void LogFormat(IFormatProvider provider, string format, object[] args)
        {
            _logger.WarnFormat(provider, format, args);
        }
    }
}
