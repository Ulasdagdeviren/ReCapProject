using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace ReCapProject.Core.CrossCutingConcern.Logging.Log4Net.Loggers
{
   public class FileLogger:LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger("FileLogger"))
        {
        }
    }
}
