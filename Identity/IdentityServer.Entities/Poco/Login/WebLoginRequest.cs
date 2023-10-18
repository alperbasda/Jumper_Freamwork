namespace IdentityServer.Entities.Poco.Login
{
    public class WebLoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; } = true;
    }
}
