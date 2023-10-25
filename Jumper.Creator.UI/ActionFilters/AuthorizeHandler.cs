using Core.ApiHelpers.JwtHelper.Encyption;
using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Features.Auth.Commands.RefreshToken;
using Jumper.Common.Constants;
using Jumper.Creator.UI.AuthHelpers;
using Jumper.Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Jumper.Creator.UI.ActionFilters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeHandlerAttribute : Attribute, IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        TokenParameters tokenParameters = context.HttpContext.RequestServices.GetService<TokenParameters>()!;

        tokenParameters.IpAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? " ";

        if (context.HttpContext.Request.Cookies.TryGetValue("Authorization", out string? jwt))
        {
            jwt = CreateTokenFromRefreshTokenIfTokenInvalid(context.HttpContext, jwt);


            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            if (token == null)
            {
                FillTempDataAndThrowException(context.HttpContext);
            }

            tokenParameters.AccessToken = jwt;

            var identity = new ClaimsIdentity(token!.Claims, "basic");
            context.HttpContext.User = new ClaimsPrincipal(identity);
            if (!string.IsNullOrEmpty(context.HttpContext?.User?.Identity?.Name))
                tokenParameters.UserName = context.HttpContext.User.Identity.Name;

            tokenParameters.UserId = Guid.Empty;
            var userIdClaim = token.Claims.FirstOrDefault(w => w.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userIdClaim))
                tokenParameters.UserId = Guid.Parse(userIdClaim);

            tokenParameters.IsSuperUser = token.Claims.Any(w => w.Type == "scope" && w.Value == "admin_user_scope");

            context.HttpContext!.Response.HttpContext.User = new ClaimsPrincipal(identity);

            return;
        }

        FillTempDataAndThrowException(context.HttpContext);

    }

  

    private string CreateTokenFromRefreshTokenIfTokenInvalid(HttpContext context, string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            handler.ValidateToken(token, GetTokenOptions(context), out _);

            return token;
        }
        catch (Exception e)
        {
            if (context.Request.Cookies.TryGetValue("AuthenticationToken", out string? refreshToken))
            {
                IMediator mediatr = context.RequestServices.GetService<IMediator>()!;
                AuthHelper authHelper = context.RequestServices.GetService<AuthHelper>()!;
                var newToken = mediatr!.Send(new RefreshTokenCommand { RefreshToken = refreshToken }).Result;
                authHelper!.Login(newToken);

                return newToken.AccessToken;
            }
            FillTempDataAndThrowException(context);
            //Bu satıra gelmeden exception fırlayacak zaten. 
            return token;
        }
    }

    private void FillTempDataAndThrowException(HttpContext context)
    {
        ITempDataProvider tempDataProvider = context.RequestServices.GetService<ITempDataProvider>()!;

        var dict = new Dictionary<string, object>
        {
            { "Error", "Lütfen Giriş Yapın." }
        };
        tempDataProvider.SaveTempData(context, dict);

        throw new AuthorizationException(AuthHelper.LoginUrl, "Lütfen Giriş Yapın");
    }

    private TokenValidationParameters GetTokenOptions(HttpContext context)
    {
        JwtTokenOptions jwtTokenOptions = context.RequestServices.GetService<JwtTokenOptions>()!;
        return new TokenValidationParameters()
        {
            ValidIssuer = jwtTokenOptions!.Issuer,
            ValidAudience = jwtTokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(jwtTokenOptions.SecurityKey),
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    }

}
