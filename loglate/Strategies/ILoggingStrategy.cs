using System;
using System.Collections.Generic;

namespace loglate.Strategies
{
    public interface ILoggingStrategy
    {
        void Log(object message);
        void Log(object message, Exception exception);
        void LogFormat(string format, object[] args);
        void LogFormat(string format, List<object> argList);
        void LogFormat(IFormatProvider provider, string format, object[] args);
    }
}