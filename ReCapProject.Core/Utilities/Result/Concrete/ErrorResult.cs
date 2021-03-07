using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Result.Concrete
{
   public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(message, false)
        {
        }

        public ErrorResult(bool success) : base(false)
        {
        }
    }
}
