using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Utilities.Result.Abstract;

namespace ReCapProject.Core.Utilities.BusinessRules
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] logic)
        {
            foreach (var result in logic)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
