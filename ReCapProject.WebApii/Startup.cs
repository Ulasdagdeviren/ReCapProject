using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete.Managers;
using ReCapProject.Core.DependencyResolves;
using ReCapProject.Core.Extensions;
using ReCapProject.Core.Utilities.IoC;
using ReCapProject.Core.Utilities.Security.Encriyption;
using ReCapProject.Core.Utilities.Security.JWT;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework;

namespace ReCapProject.WebApii
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddControllers();
            //services.AddSingleton<ICarService, CarManager>();// e�er bir ba��ml�l�k g�r�rsen ICarService onun kar��l��� CarManager d�r
            //services.AddSingleton<ICarDal, EfCarDal>();
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Jwt beader install
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, 
                        ValidateAudience = true,
                        ValidateLifetime = true,// token�n ya�am �mr�n� kontrol edeyim mi token olsa yeter mibiz 10 dk dedik
                        ValidIssuer = tokenOptions.Issuer, // e mail 
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true, // anahtar� kontrol edeyim mi
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
             services.AddDependencyResolves(new ICoreModule[]
            {
                new CoreModule()
            });
        }  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // biz yazd�k middler lear hangi yap�lar s�ras�yla girecek s�rayla eve girmek i�in anahtar
            app.UseAuthorization();// istemedi�imiz yerlere girmez 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
