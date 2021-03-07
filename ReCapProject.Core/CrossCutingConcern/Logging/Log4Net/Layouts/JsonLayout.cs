using System.IO;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

namespace ReCapProject.Core.CrossCutingConcern.Logging.Log4Net.Layouts
{
   public class JsonLayout:LayoutSkeleton
   {

       public override void ActivateOptions()
        {
            
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new Serializable(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);
            writer.WriteLine(json);
        }
    }
}
