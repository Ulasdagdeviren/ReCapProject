using System;
using log4net.Core;

namespace ReCapProject.Core.CrossCutingConcern.Logging.Log4Net
{
    [Serializable]
   public class Serializable
   {
       private LoggingEvent _loggingEvent;

       public Serializable(LoggingEvent loggingEvent)
       {
           _loggingEvent = loggingEvent;
       }

       public string UserName => _loggingEvent.UserName;
       public object MessageObject => _loggingEvent.MessageObject;
   }
}
