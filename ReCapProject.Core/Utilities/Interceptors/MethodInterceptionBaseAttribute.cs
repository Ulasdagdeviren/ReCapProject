using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace ReCapProject.Core.Utilities.Interceptors
{
    // AOP desteğini sağlayacak alt yapı Autofac ve Proxy den geliyor
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] // classlara veya methodlara ekleyebilirsin bu etribütü ,birden fazla ekleyebilirsin
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } // öncelik değeri demek   

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}

