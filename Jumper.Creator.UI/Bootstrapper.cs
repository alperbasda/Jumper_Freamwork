using Microsoft.AspNetCore.Authentication.Cookies;
using Jumper.Creator.UI.AuthHelpers;
using Core.ApiHelpers.JwtHelper.Models;
using StackExchange.Redis;
using Core.Application.Pipelines.Caching;
using Jumper.Domain.Configurations;
using Jumper.Application.Features.Auth.HttpClients;

namespace Jumper.Creator.UI;

public static class Bootstrapper
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheSettings = services.AddSettingsSingleton<CacheSettings>(configuration);
        services.AddRedis(cacheSettings);
        services.AddIdentityOptions(configuration);

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

        services.AddScoped<AuthHelper>();
        services.AddScoped<TokenParameters>();


        return services;
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


}
