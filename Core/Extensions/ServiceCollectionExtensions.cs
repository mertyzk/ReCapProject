using System;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions // Extension metodu yazabilmek için o classın static olması gerekir.
    {
        // IServiceCollection bizim ASP.NET uygulamamızın (kısacası API'mizin) servis bağımlılıklarını eklediğimiz ya da araya girmesini istediğimiz servisleri eklediğimiz koleksiyonun kendisidir.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules) // İstediğim kadar resolveri yani ICoreModule olan şeyleri buraya ekleyebiliriz. Polimorfizm yapacağız aslında.
        {
            //CoreModule bir ICoreModule. Yarın başka bir modül oluşturduğumuzda onu da ICoreModule'dan implemente edersek,orada da bambaşka implementasyonlarımızı yapabiliriz.
            foreach (var module in modules)
            {
                module.Load(serviceCollection); // Birden fazla modülü ekleyebileceğimizi gösteriyor
            }

            return ServiceTool.Create(serviceCollection);
        }  
    }
}
