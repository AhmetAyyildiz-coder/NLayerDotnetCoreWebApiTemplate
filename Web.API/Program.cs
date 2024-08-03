using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using Core;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.DependencyResolvers;
using Core.Utilities.Ioc;
using Persistence;
using Core.Persistence;
using Repository;

namespace Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(containerBuilder =>
                {
                    containerBuilder.RegisterModule(new AutofacBusinessModule());
                });
            


            builder.Services.AddControllers(config =>
            {
                // api tarafındaki response'ları global olarak düzenlemek için ekledik.
                // config.Filters.Add(new GlobalResponseFilter());
            });
            builder.Services.AddHttpContextAccessor();

            // Core katmanindaki DI container nesnelerini bu sekilde ekliyoruz.
            builder.Services.RegisterCoreLayer(new ICoreModule[] { new CoreModule() });

            // repository katmanindaki DI container nesnelerini bu sekilde ekliyoruz.
            builder.Services.RegisterRepositoryLayer(builder.Configuration);
            
            // Business katmanindaki DI container nesnelerini bu sekilde ekliyoruz.
            builder.Services.RegisterBusinessLayer(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // global exteption handler mechanizm 
            app.ConfigureCustomExceptionMiddleware();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
