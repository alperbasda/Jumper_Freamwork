﻿using Core.ApiHelpers.JwtHelper.Models;
using Core.Application.Pipelines.Caching;
using Jumper.Application.Features.Auth.HttpClients;
using Jumper.CodeGenerator.BuilderBase.ArchitectureCreators;
using Jumper.CodeGenerator.BuilderBase.Helpers;
using Jumper.CodeGenerator.BuilderBase.Starters;
using Jumper.Common.FileHelpers;
using Jumper.Domain.Configurations;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Authentication.Cookies;
using StackExchange.Redis;
using System.Reflection;

namespace Jumper.CodeGenerator.Api.Midllewares;

public static class AddCodeGeneratorMiddleware
{
    public static IServiceCollection AddCodeGeneratorServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());


            ///Dikkat.Aynı anda dbye erişmesi gereken işlemlerde publish kullanırsan naneyi yersin haberin olsun.
            configuration.NotificationPublisher = new TaskWhenAllPublisher();
            configuration.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            configuration.Lifetime = ServiceLifetime.Scoped;
        });


        services.AddIdentityOptions(configuration);
        services.AddScoped<FileHelper>();
        services.AddScoped<ProjectFileCreatorStarter>();
        
        


        services.AddScoped<IArchitectureCreator, ArchitectureCreator>();
        var cacheSettings = services.AddSettingsSingleton<CacheSettings>(configuration);
        services.AddRedis(cacheSettings);
        
        //Bazı durumlarda service scopetan cagırım gerekebilir. Bu durumlarda root provider bazen işe yaramaz ve nesneyi burdan çağırmak gerekir.
        ScopeSafeServiceProvider.Create(services);
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
            }



            else
                addWithLifeCycle(services, type);
        return services;
    }

    public static IServiceCollection AddIdentityOptions(this IServiceCollection services, IConfiguration configuration)
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


        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/auth/login/";
                });

        services.AddScoped<TokenParameters>();


        return services;
    }


    public static void AddAmqpServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<CreateProjectCommandConsumer>();
        //services.AddMassTransit(x =>
        //{
        //    x.AddConsumer<CreateProjectCommandConsumer>();
        //    x.UsingRabbitMq((ctx, cfg) =>
        //    {
        //        cfg.Host(configuration["RabbitMq:Host"], ushort.Parse(configuration["RabbitMq:Port"]!), "/", host =>
        //        {
        //            host.Username(configuration["RabbitMq:UserName"]);
        //            host.Password(configuration["RabbitMq:Password"]);
        //        });

        //        cfg.ReceiveEndpoint(QueueNames.CreateProjectName, e =>
        //        {
        //            e.PrefetchCount = 100;
        //            e.ConfigureConsumer(ctx, typeof(CreateProjectCommandConsumer));

        //        });

        //    });
        //});

        //services.Configure<MassTransitHostOptions>(options =>
        //{
        //    options.WaitUntilStarted = false;
        //    options.StartTimeout = TimeSpan.FromSeconds(5);
        //    options.StopTimeout = TimeSpan.FromMinutes(1);
        //});

    }
}
