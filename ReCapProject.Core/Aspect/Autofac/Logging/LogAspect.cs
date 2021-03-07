using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using ReCapProject.Core.CrossCutingConcern.Logging;
using ReCapProject.Core.CrossCutingConcern.Logging.Log4Net;
using ReCapProject.Core.Utilities.Interceptors;

namespace ReCapProject.Core.Aspect.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerService _loggerService;
        private Type _loggerType;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;

            if (loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Manager");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(loggerType);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerService.Info(GetLogDetail(invocation)); // invocation methodtur atıyorum bussines amaçlı ise add dir invocation update delete vs
        }

        private object GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name, // concrete =somut
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
            var logDetail = new LogDetail
            {
                LogParameters = logParameters,
                MethodName = invocation.Method.Name
            };
            return logDetail;
        }
    }
}
