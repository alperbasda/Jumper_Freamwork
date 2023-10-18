using IdentityServer.Business.Contracts;
using IdentityServer.Entities.Poco.Login;
using JwtHelpers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UIHelpers;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly TokenParameters _tokenParameters;
        public AuthController(IAuthenticationService authenticationService, TokenParameters tokenParameters)
        {
            _authenticationService = authenticationService;
            _tokenParameters = tokenParameters;
        }

        [HttpPost("")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Token üretmek için kullanılır. (Policy : AllowAnonymous)")]
        public async Task<IActionResult> CreateToken(UserLoginRequest request)
        {
            return CreateActionResult(await _authenticationService.CreateToken(request));
        }

        [HttpDelete]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Header ile gelen tokenin refresh tokenlerini kaldırır. (Policy : LoggedUser)")]
        public async Task<IActionResult> RevokeRefreshToken()
        {
            return CreateActionResult(await _authenticationService.RevokeRefreshToken(_tokenParameters.UserId));
        }

        [HttpGet("revoke/{refreshToken}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Refresh token oturumu kapatmayı sağlar. (Policy : AllowAnonymous)")]
        public async Task<IActionResult> RevokeRefreshToken(string refreshToken)
        {
            return CreateActionResult(await _authenticationService.RevokeRefreshToken(refreshToken));
        }

        [HttpGet("{refreshToken}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Refresh token ile access token alınmasını sağlar. (Policy : AllowAnonymous)")]
        public async Task<IActionResult> CreateTokenByRefreshToken(string refreshToken)
        {
            return CreateActionResult(await _authenticationService.CreateTokenByRefreshToken(refreshToken));
        }
    }
}
