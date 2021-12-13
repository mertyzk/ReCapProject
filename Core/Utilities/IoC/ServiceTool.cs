using System;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) // IServiceCollection Microsoft.Extensions.DependencyInjection'dan geliyor.
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
