using IdentityServer.Business.Business.Encyption;
using IdentityServer.Business.Constants;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.Encyption;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Client;
using IdentityServer.Entities.Poco.Token;
using JwtHelpers.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace IdentityServer.Business.Concrete
{
    public class TokenManager : ITokenService
    {
        JwtOptions _jwtOptions;

        public TokenManager(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public ClientTokenResponse CreateClientToken(ClientResponse client)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_jwtOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: GetClaimsByClient(client),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new ClientTokenResponse
            {
                AccessToken = token,
            };

            return tokenDto;
        }

        public UserTokenResponse CreateUserToken(IdentityUser user, string clientId)
        {

            var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_jwtOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                 issuer: _jwtOptions.Issuer,
                 expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: GetClaimsByUser(user, clientId),
                 signingCredentials: signingCredentials,
                 audience: _jwtOptions.Audience
                 );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new UserTokenResponse
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                RefreshTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.RefreshTokenExpiration)
            };

            return tokenDto;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaimsByClient(ClientResponse client)
        {
            var claims = new List<Claim>();
            if (client.ClientScopes.Any())
            {
                claims.AddRange(client.ClientScopes.Select(x => new Claim("scope", x.Scope)));
            }
            claims.AddRange(AuthConfig.ClientResources.Where(w => w.ClientId == client.Id).Select(x => new Claim(JwtRegisteredClaimNames.Aud, x.ApiResourceName)));
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            new Claim(JwtRegisteredClaimNames.Sub, client.ClientId);

            return claims;
        }

        private IEnumerable<Claim> GetClaimsByUser(IdentityUser user, string clientId)
        {
            var userList = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, clientId),
        };

            if (user.IdentityUserScopes.Any())
            {
                userList.AddRange(user.IdentityUserScopes.Select(x => new Claim("scope", x.Scope)));
            }

            var client = AuthConfig.Clients.FirstOrDefault(x => x.ClientId == clientId);
            if (client != null)
            {
                userList.AddRange(AuthConfig.ClientResources.Where(w => w.ClientId == client.Id).Select(x => new Claim(JwtRegisteredClaimNames.Aud, x.ApiResourceName)));
            }


            return userList;
        }
    }
}
