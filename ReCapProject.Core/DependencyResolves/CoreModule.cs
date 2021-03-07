using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Core.CrossCutingConcern.Caching;
using ReCapProject.Core.CrossCutingConcern.Caching.Microsoft;
using ReCapProject.Core.Utilities.IoC;

namespace ReCapProject.Core.DependencyResolves
{
  public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
