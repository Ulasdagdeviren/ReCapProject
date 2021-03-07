using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete.Managers;
using ReCapProject.Core.Utilities.Interceptors;
using ReCapProject.Core.Utilities.Security.JWT;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework;

namespace ReCapProject.Business.DependcyResolves.Autofac
{
    // eklediklerimiz :Autofac,Autofac.extract.proxy // proxy ile Aop yapıtğımız kısım
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Car
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            ////Brand
            //builder.RegisterType<BrandManager>().As<IBrandService>();
            //builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            ////Color
            //builder.RegisterType<ColorManager>().As<IColorService>();
            //builder.RegisterType<EfColorDal>().As<IColorDal>();
            //Customer
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            //User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            //Rental
            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            //Rental
            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); // burası Autofac üzerinden aspect yapmıştık validationı kullanmak için 26-31 arası
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
