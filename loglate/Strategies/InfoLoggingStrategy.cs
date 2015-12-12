using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Strategies
{
    public class InfoLoggingStrategy : ILoggingStrategy
    {
        ILog _logger;
        public InfoLoggingStrategy(ILog logger)
        {
            _logger = logger;
        }
        public void Log(object message)
        {
            _logger.Info(message);
        }
        public void Log(object message, Exception exception)
        {
            _logger.Info(message, exception);
        }
        
        public void LogFormat(string format, List<object> argList)
        {
            switch(argList.Count)
            {
                case 1: _logger.InfoFormat(format, argList[0]); break;
                case 2: _logger.InfoFormat(format, argList[0], argList[1]); break;
                case 3: _logger.InfoFormat(format, argList[0], argList[1], argList[2]); break;
                default: throw new ArgumentException("Too many arguments");
            }
        }
        public void LogFormat(string format, object[] args) {
            _logger.InfoFormat(format, args);
        }
        public void LogFormat(IFormatProvider provider, string format, object[] args)
        {
            _logger.InfoFormat(provider, format, args);
        }
    }
}
