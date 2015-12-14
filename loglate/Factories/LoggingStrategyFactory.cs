using log4net;
using loglate.Enums;
using loglate.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Factories
{
    public class LoggingStrategyFactory
    {
        public static ILoggingStrategy GetStrategy(LogLevel logLevel, ILog logger)
        {
            if(logger == null)
            {
                throw new ArgumentException("Logger can not be null");
            }

            switch(logLevel)
            {
                case LogLevel.Debug: return new DebugLoggingStrategy(logger);
                case LogLevel.Error: return new ErrorLoggingStrategy(logger);
                case LogLevel.Fatal: return new FatalLoggingStrategy(logger);
                case LogLevel.Info: return new InfoLoggingStrategy(logger);
                case LogLevel.Warn: return new WarnLoggingStrategy(logger);
                default: throw new ArgumentException("Invalid loglevel");
            }
        }
    }
}
