using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Result.Concrete
{
   public class SuccessResult:Result
    {
        

        public SuccessResult(string message) : base(message, true)
        {
        }

        public SuccessResult(bool success) : base(true)
        {
        }

        public SuccessResult() : base(true)
        {
            
        }
    }
}
