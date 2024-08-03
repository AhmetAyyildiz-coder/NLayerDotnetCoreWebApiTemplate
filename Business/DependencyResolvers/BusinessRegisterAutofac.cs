using System.Reflection;
using Autofac;
using Business.Concrete;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.JWT;
using Repository.Abstract;
using Repository.Concrete;
using Module = Autofac.Module;

namespace Business.DependencyResolvers;

/// <summary>
///     IOC container
/// </summary>
public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
    

        //builder.RegisterType<UserManager>().As<IUserService>();
        //builder.RegisterType<EfUserRepository>().As<IUserRepository>();

        builder.RegisterType<AuthManager>().As<IAuthService>();

        builder.RegisterType<JwtHelper>().As<ITokenHelper>();


        //builder.RegisterType<EfUserOperationRepository>().As<IUserOperationRepository>();

        //builder.RegisterType<EfOperationClaimRepository>().As<IOperationClaimRepository>();

        builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();


        // dynamic proxy olusturabilmek icin gerekli ayarlamalar
        var assembly = Assembly.GetExecutingAssembly();
        
        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        //builder.RegisterAssemblyTypes(assembly)
        //   .Where(t => t.Name.EndsWith("Service"))
        //   .AsImplementedInterfaces()
        //   .InstancePerLifetimeScope();




    }
}