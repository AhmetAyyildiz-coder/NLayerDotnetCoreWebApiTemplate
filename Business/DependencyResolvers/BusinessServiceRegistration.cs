using Business.Abstract;
using Business.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers;

public static class BusinessServiceRegistration
{
    public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        var serviceAssembly = typeof(IAuthService).Assembly;
        services.AddAutoMapper(typeof(MappingProfile));

        foreach (var type in serviceAssembly.GetExportedTypes())
        {
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
                if (@interface.Name.EndsWith("Service"))
                    services.AddScoped(@interface, type);
        }

        return services;
    }
}