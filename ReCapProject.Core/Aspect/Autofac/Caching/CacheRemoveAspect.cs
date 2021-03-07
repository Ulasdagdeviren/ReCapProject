using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Core.CrossCutingConcern.Caching;
using ReCapProject.Core.Utilities.Interceptors;
using ReCapProject.Core.Utilities.IoC;

namespace ReCapProject.Core.Aspect.Autofac.Caching
{
   public class CacheRemoveAspect:MethodInterception
   {
       private string _pattern;
       private ICacheManager _manager;

       public CacheRemoveAspect(string pattern)
       {
           _pattern = pattern;
           _manager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
       }

       protected override void OnSuccess(IInvocation invocation)
       {
           _manager.RemoveByPattern(_pattern);
       }
   }
}
