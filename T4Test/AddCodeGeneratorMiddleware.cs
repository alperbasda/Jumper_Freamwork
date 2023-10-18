using Core.ApiHelpers.JwtHelper.Models;
using Core.Application.Pipelines.Caching;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Reflection;

namespace T4Test;
public static class AddCodeGeneratorMiddleware
{
    public static IServiceCollection AddCodeGeneratorServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(configuration);
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());


            ///Dikkat.Aynı anda dbye erişmesi gereken işlemlerde publish kullanırsan naneyi yersin haberin olsun.
            configuration.NotificationPublisher = new TaskWhenAllPublisher();
            configuration.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            configuration.Lifetime = ServiceLifetime.Scoped;
        });


        services.AddScoped<TokenParameters>();


        var cacheSettings = services.AddSettingsSingleton<CacheSettings>(configuration);
        services.AddRedis(cacheSettings);

        return services;
    }

    public static T AddSettingsSingleton<T>(this IServiceCollection services, IConfiguration configuration)
        where T : class, new()
    {
        T settings = new T();
        configuration.GetSection(settings.GetType().Name).Bind(settings);

        services.Configure<T>(options =>
        {
            options = settings;
        });
        services.AddSingleton<T>(sp =>
        {
            return settings;
        });

        return settings;
    }

    public static void AddRedis(this IServiceCollection services, CacheSettings cacheSettings)
    {
        services.AddStackExchangeRedisCache(opt =>
        {

            opt.ConfigurationOptions = new ConfigurationOptions
            {
                Password = cacheSettings.Password,
                EndPoints =
                    {
                        { cacheSettings.Host, int.Parse(cacheSettings.Port) }
                    },
            };
        });
    }

    public static IServiceCollection AddSubClassesOfType(
      this IServiceCollection services,
      Assembly assembly,
      Type type,
      Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => type.IsAssignableFrom(t) && !t.IsAbstract).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
            {
                services.AddScoped(item);
                services.AddScoped(c => c.GetService(item));
            }



            else
                addWithLifeCycle(services, type);
        return services;
    }

}

