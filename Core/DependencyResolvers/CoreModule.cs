using System.Diagnostics;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Logging.Logger;
using Core.Logging.Serilog;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Core.DependencyResolvers;

/// <summary>
/// Api projelerine ait core olan modülleri tutar.
/// </summary>
public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection collection)
    {
        collection.AddMemoryCache();

        collection.AddSingleton<ICacheManager, MemoryCacheManager>();

        collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        collection.AddSingleton<Stopwatch>();
        collection.AddSingleton<LoggerServiceBase, MsSqlLogger>();

    }
}