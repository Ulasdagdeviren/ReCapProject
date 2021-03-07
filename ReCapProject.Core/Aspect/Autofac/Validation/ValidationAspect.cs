using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using FluentValidation;
using ReCapProject.Core.CrossCutingConcern.Validation.FluentValidation;
using ReCapProject.Core.Utilities.Interceptors;
using ReCapProject.Core.Utilities.Messages;

namespace ReCapProject.Core.Aspect.Autofac.Validation
{
   public class ValidationAspect:MethodInterception
   {
       private Type _validatorType;

       public ValidationAspect(Type validatorType)
       {
           if (!typeof(IValidator).IsAssignableFrom(validatorType))
           {
               throw new Exception(AspectMessages.WrongValidationType);
           }
           _validatorType = validatorType;
       }
        // önemli!!!! invocation method demektir
       protected override void OnBefore(IInvocation invocation)
       {
           var validator = (IValidator) Activator.CreateInstance(_validatorType); // biz newleme işini mehod çalıştığı anda yapmak istiyoruz
           var entityType = _validatorType.BaseType.GetGenericArguments()[0];
           var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
           foreach (var entity in entities)
           {
               ValidatorTool.Validator(validator,entity);
           }
       }
   }
}
