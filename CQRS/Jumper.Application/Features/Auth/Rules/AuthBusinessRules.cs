using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Models.Responses;
using Jumper.Application.Base;
using Jumper.Application.Features.Auth.Commands.Login;
using Jumper.Application.Features.Auth.Commands.RefreshToken;

namespace Jumper.Application.Features.Auth.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    public const string LoginUrl = "/Auth/Login";

    public AuthBusinessRules(TokenParameters tokenParameters) : base(tokenParameters)
    {
            
    }
    public void ThrowExceptionIfLoginFailed(Response<LoginResponse> response) 
    {
        if (!response.IsSuccessful)
        {
            throw new AuthorizationException(LoginUrl, string.Join("<br/>", response.Errors));
        }
    }

    public void ThrowExceptionIfLoginFailed(Response<RefreshTokenResponse> response)
    {
        if (!response.IsSuccessful)
        {
            throw new AuthorizationException(LoginUrl, string.Join("<br/>", response.Errors));
        }
    }

}
