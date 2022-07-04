using Domain.Interfaces;
using Infrastructure.Database;
using Infrastructure.Services;
using Infrastructure.Rules;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(DI.Assembly)
                    .AddClasses(classes => classes.AssignableTo<IRuleSet>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());

            services.AddTransient<IVaccinceCriteriaHandler, VaccinceCriteriaHandler>();
            services.AddSingleton<IDataLayer, DataLayer>();
            //services.AddTransient<IRuleSet>();
        }
    }
}
