using Core.DependencyResolvers;
using Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class CoreLayerDIRegister
    {
        public static IServiceCollection RegisterCoreLayer(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
