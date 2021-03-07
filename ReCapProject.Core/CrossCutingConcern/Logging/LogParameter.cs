using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.CrossCutingConcern.Logging
{
   public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
    }
}
