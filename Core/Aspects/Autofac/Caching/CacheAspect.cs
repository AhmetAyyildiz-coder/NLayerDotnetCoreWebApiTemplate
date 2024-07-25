using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching;

/// <summary>
///  Cache yapabilmek için kullanılan aspect'tir.eğer cache'de varsa cache'den getirir yoksa methodu çalıştırır ve cache ekler.
/// </summary>
public class CacheAspect : MethodInterception
{
    private int _duration;//dakika
    private ICacheManager _cacheManager;
    public CacheAspect(int duration= 60) 
    {
        _duration = duration;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }



    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

        if (_cacheManager.IsAdd(key))
        {
            // method'un return değerini bu şekilde değiştirebilmekteyiz.
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }
        invocation.Proceed();
        _cacheManager.Add(key,invocation.ReturnValue,_duration);

    }
}