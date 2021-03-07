using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Business.Cantact;
using ReCapProject.Core.Extensions;
using ReCapProject.Core.Utilities.Interceptors;
using ReCapProject.Core.Utilities.IoC;

namespace ReCapProject.Business.BusinessAspect.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // JWT için

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return; // methodu çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied); // yetkisi yok dedik
        }
    }
}
