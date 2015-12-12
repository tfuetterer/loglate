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

            if (logLevel == LogLevel.Debug)
            {
                return new DebugLoggingStrategy(logger);
            }

            if (logLevel == LogLevel.Error)
            {
                return new ErrorLoggingStrategy(logger);
            }

            if (logLevel == LogLevel.Fatal)
            {
                return new FatalLoggingStrategy(logger);
            }

            if (logLevel == LogLevel.Info)
            {
                return new InfoLoggingStrategy(logger);
            }

            if (logLevel == LogLevel.Warn)
            {
                return new WarnLoggingStrategy(logger);
            }

            throw new ArgumentException("Invalid loglevel");
        }
    }
}
