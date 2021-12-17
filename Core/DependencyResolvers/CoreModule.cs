using System;
using System.Diagnostics;
using Core.CrossCuttingConcers.Caching;
using Core.CrossCuttingConcers.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule // Uygulama seviyesindeki servis bağımlılığını çözümleyeceğimiz yer. 
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
