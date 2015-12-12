using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Factories
{
    public class LoggingManagerFactory
    {
        public static ILog GetLoggingManager(ILog logger)
        {
            return new DelayedLoggingManager(logger);
        }
    }
}
