using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Core.Utilities.IoC;

namespace ReCapProject.Core.Extensions
{
   public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolves(
                this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var coreModule in modules)
            {
                coreModule.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }

    }
}
