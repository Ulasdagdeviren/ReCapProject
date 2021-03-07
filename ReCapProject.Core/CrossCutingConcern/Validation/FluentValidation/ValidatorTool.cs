using System;
using FluentValidation;

namespace ReCapProject.Core.CrossCutingConcern.Validation.FluentValidation
{
   public class ValidatorTool
    {
        public static void Validator(IValidator validator,object entity) // IValidator doğrulama kuralları ,entity doğrulanaca olan Product gibi
        {
            var context=new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
