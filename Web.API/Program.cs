using Core;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.DependencyResolvers;
using Core.Utilities.Ioc;
namespace Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            
            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            // Core katman�ndaki DI container nesnelerini bu �ekilde ekliyoruz.
            builder.Services.RegisterCoreLayer(new ICoreModule[] { new CoreModule() });


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
