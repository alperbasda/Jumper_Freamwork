using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Business.Business.Encyption
{
    public class SigningCredentialsHelper 
    { 
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
