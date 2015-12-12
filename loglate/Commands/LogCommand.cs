using log4net;
using loglate.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate.Commands
{
    public class LogCommand : ILogCommand
    {
        #region Fields
        protected object _message;
        protected Exception _exception;
        protected string _format;
        protected object[] _args;
        protected IFormatProvider _provider;
        protected List<object> _argList;
        protected ILoggingStrategy _loggingStrategy;
        #endregion

        public LogCommand(object message, ILoggingStrategy loggingStrategy)
        {
            _loggingStrategy = loggingStrategy;
            _message = message;
        }

        public LogCommand(object message, Exception exception, ILoggingStrategy loggingStrategy)
        {
            _loggingStrategy = loggingStrategy;
            _message = message;
            _exception = exception;
        }

        public LogCommand(string format, List<object> argList, ILoggingStrategy loggingStrategy)
        {
            _loggingStrategy = loggingStrategy;
            _format = format;
            _argList = argList;
        }

        public LogCommand(string format, object[] args, ILoggingStrategy loggingStrategy)
        {
            _loggingStrategy = loggingStrategy;
            _format = format;
            _args = args;
        }

        public LogCommand(IFormatProvider provider, string format, object[] args, ILoggingStrategy loggingStrategy)
        {
            _loggingStrategy = loggingStrategy;
            _provider = provider;
            _format = format;
            _args = args;
        }

        public void PerfomLog()
        {
            if (_message != null && _exception == null)
                _loggingStrategy.Log(_message);
            if (_message != null && _exception != null)
                _loggingStrategy.Log(_message, _exception);
            if (_format != null && _argList != null)
                _loggingStrategy.LogFormat(_format, _argList);
            if (_format != null && _args != null && _provider == null)
                _loggingStrategy.LogFormat(_format, _args);
            if (_format != null && _args != null && _provider != null)
                _loggingStrategy.LogFormat(_provider, _format, _args);
        }
    }
}
