using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Strategies
{
    public class FatalLoggingStrategy : ILoggingStrategy
    {
        ILog _logger;
        public FatalLoggingStrategy(ILog logger)
        {
            _logger = logger;
        }
        public void Log(object message)
        {
            _logger.Fatal(message);
        }
        public void Log(object message, Exception exception)
        {
            _logger.Fatal(message, exception);
        }
        
        public void LogFormat(string format, List<object> argList)
        {
            switch(argList.Count)
            {
                case 1: _logger.FatalFormat(format, argList[0]); break;
                case 2: _logger.FatalFormat(format, argList[0], argList[1]); break;
                case 3: _logger.FatalFormat(format, argList[0], argList[1], argList[2]); break;
                default: throw new ArgumentException("Too many arguments");
            }
        }
        public void LogFormat(string format, object[] args) {
            _logger.FatalFormat(format, args);
        }
        public void LogFormat(IFormatProvider provider, string format, object[] args)
        {
            _logger.FatalFormat(provider, format, args);
        }
    }
}
