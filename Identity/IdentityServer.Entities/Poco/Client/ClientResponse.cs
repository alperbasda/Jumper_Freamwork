using EntityBase.Poco.GetModelBase.Concrete;
using System.Text.Json.Serialization;

namespace IdentityServer.Entities.Poco.Client
{
    public class ClientResponse : GetModel
    {
        public string ClientId { get; set; }

        public string Name { get; set; }

        public string ClientSecretStr { get; set; }

        [JsonIgnore]
        public byte[] ClientSecret { get; set; }

        [JsonIgnore]
        public byte[] ClientSecretSalt { get; set; }

        public string ClientUrl { get; set; }

        public string LogoUrl { get; set; }

        public string LoginRedirectUrl { get; set; }

        public string LogoutRedirectUrl { get; set; }

        public virtual List<ClientScopeResponse> ClientScopes { get; set; }
    }
}
