﻿//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper template tool. 
//---------------------------------------------------------------------------------------
namespace IdentityServer.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenResponse
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public DateTime RefreshTokenExpiration { get; set; }
}
