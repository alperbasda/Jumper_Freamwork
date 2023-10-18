namespace IdentityServer.Entities.Poco.Login
{
    public class PhoneLoginRequest
    {
        public string Target { get; set; }

        public string Code { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
