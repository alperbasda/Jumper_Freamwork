namespace IdentityServer.Entities.Poco.Token
{

 
    public class UserTokenResponse
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }



}
