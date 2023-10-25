﻿using Jumper.Application.Features.Auth.Commands.Login;
using Jumper.Application.Features.Auth.Commands.RefreshToken;
using Jumper.Common.Constants;
using Newtonsoft.Json;

namespace Jumper.Creator.UI.AuthHelpers;

public class AuthHelper
{
    IHttpContextAccessor _httpContextAccessor;

    public const string LoginUrl = "Auth/Login";

    public AuthHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Login(LoginResponse response)
    {
        _httpContextAccessor.HttpContext!.Response.Cookies.Append("Authorization", response.AccessToken);
        _httpContextAccessor.HttpContext!.Response.Cookies.Append("AuthenticationToken", response.RefreshToken);
    }

    public void Login(RefreshTokenResponse response)
    {
        _httpContextAccessor.HttpContext!.Response.Cookies.Append("Authorization", response.AccessToken);
        _httpContextAccessor.HttpContext!.Response.Cookies.Append("AuthenticationToken", response.RefreshToken);
    }

    public void LogOut()
    {
        _httpContextAccessor.HttpContext!.Response.Cookies.Delete("Authorization");
        //_httpContextAccessor.HttpContext!.Response.Cookies.Delete("AuthenticationToken");
    }

    public string GetAccessToken()
    {
        return _httpContextAccessor.HttpContext!.Request.Cookies["Authorization"]!;
    }

    public string GetRefreshToken()
    {
        return _httpContextAccessor.HttpContext!.Request.Cookies["AuthenticationToken"]!;
    }

}
