using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Result.Abstract;

namespace ReCapProject.Core.Result.Concrete
{
   public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data,string message, bool success) : base(message, success)
        {
            Data = data;
        }

        public DataResult(T data,bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
