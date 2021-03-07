using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ReCapProject.Core.Utilities.IoC
{
    public class ServiceTool // Aspectlerde Servis sağlayııcı oluşturduk
    {
        public static IServiceProvider ServiceProvider { get; private set; } // servis sağlayıcı demek ServiceProvider 

        public static IServiceCollection Create(IServiceCollection services) // biz form kullansak nasl injection yapcaktık bu sayede her yerde ınjectiion yapılır
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }

    }
}
