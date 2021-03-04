using System.Diagnostics;
using Core.CrossCuttingConserns.Caching;
using Core.CrossCuttingConserns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //microsoft memory cach managerin bagınıda burda cozuyoruz
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //standart injection olusturdugumuz interface ve managerları veriyoruz
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
