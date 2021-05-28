using BF.Dependency;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF
{
    public static class BootstrampperExtensions
    {
        public static IServiceProvider AddBootstrapper(this IServiceCollection services,object obj, Microsoft.Extensions.Configuration.IConfiguration configuration) {



            var bootstrapper = Bootstrapper.Create(obj.GetType(), configuration);
            services.AddSingleton(bootstrapper);

            ConfigureAspNetCore(services, bootstrapper.IocManager);

            return WindsorRegistrationHelper.CreateServiceProvider(bootstrapper.IocManager.IocContainer, services);
        }

        private static void ConfigureAspNetCore(IServiceCollection services, IIocManager iocManager)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        public static IApplicationBuilder UseBootstrapper(this IApplicationBuilder builder) {
             var bootstrapper=builder.ApplicationServices.GetRequiredService<Bootstrapper>();
            bootstrapper.Initialize();
            return builder;
        }
    }
}
