using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Contexts;

namespace Repository
{
    public static class RepositoryServiceRegistration
    {
        public static IServiceCollection RegisterRepositoryLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MssqlConnection"));
            });
            
            var serviceAssembly = typeof(Repository.Abstract.IUserRepository).Assembly;

            foreach (var type in serviceAssembly.GetExportedTypes())
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    if (@interface.Name.EndsWith("Repository"))
                    {
                        services.AddScoped(@interface, type);
                    }
                }
            }

            return services;

        }
    }
}
