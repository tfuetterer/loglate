﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loglate
{
    public interface IDelayedLogger : ILog
    {
        void StoreLogs();
    }
}
