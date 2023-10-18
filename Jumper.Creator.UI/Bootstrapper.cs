using Microsoft.AspNetCore.Authentication.Cookies;
using Jumper.Creator.UI.AuthHelpers;
using Core.ApiHelpers.JwtHelper.Models;

namespace Jumper.Creator.UI;

public static class Bootstrapper
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuth(configuration);
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
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


}
