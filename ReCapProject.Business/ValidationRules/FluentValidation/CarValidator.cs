using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ReCapProject.Entities.concrete;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.ModelYear).GreaterThan(2010);
            RuleFor(x => x.DailyPrice).GreaterThan(80);
        }
    }
}
