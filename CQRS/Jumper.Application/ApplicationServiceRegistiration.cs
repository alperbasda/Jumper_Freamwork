using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Jumper.Application.Base;
using Jumper.Application.Features.Auth.HttpClients;
using Jumper.Domain.Configurations;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jumper.Application;

public static class ApplicationServiceRegistiration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddIdentityOptions(configuration);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            ///Dikkat.Aynı anda dbye erişmesi gereken işlemlerde publish kullanırsan naneyi yersin haberin olsun.
            configuration.NotificationPublisher = new TaskWhenAllPublisher();
            configuration.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            configuration.Lifetime = ServiceLifetime.Scoped;
        });

        

        return services;

    }

    public static IServiceCollection AddIdentityOptions(this IServiceCollection services,IConfiguration configuration)
    {
        IdentityApiConfiguration identityOpts = new IdentityApiConfiguration();

        configuration.GetSection("HttpClients:IdentityServer").Bind(identityOpts);
        services.Configure<IdentityApiConfiguration>(options =>
        {
            options = identityOpts;
        });
        services.AddSingleton<IdentityApiConfiguration>(sp =>
        {
            return identityOpts;
        });



        JwtTokenOptions tokenOpts = new JwtTokenOptions();

        configuration.GetSection("JwtTokenOptions").Bind(tokenOpts);
        services.Configure<JwtTokenOptions>(options =>
        {
            options = tokenOpts;
        });
        services.AddSingleton<JwtTokenOptions>(sp =>
        {
            return tokenOpts;
        });


        services.AddHttpClient<IIdentityServerClientService, IdentityServerClientService>((client) =>
        {
            client.BaseAddress = new Uri(identityOpts.BaseAddress);
        });

        return services;
    }



    public static IServiceCollection AddSubClassesOfType(
      this IServiceCollection services,
      Assembly assembly,
      Type type,
      Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }

}
