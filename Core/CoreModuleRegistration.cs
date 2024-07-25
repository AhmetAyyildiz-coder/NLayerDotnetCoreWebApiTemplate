using Core.Logging.Logger;
using Core.Logging.Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class CoreModuleRegistration
    {
        public static void RegisterCoreModule(this IServiceCollection services, IConfiguration configuration)
        {
            // base log mechanism
            services.AddSingleton<LoggerServiceBase, MsSqlLogger>();
        }
    }

}
