using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;
using System.Text.Json.Serialization;

namespace IdentityServer.Entities.Poco.Client
{
    public class CreateClientRequest : CreateModel
    {
        public string ClientId { get; set; }

        public string Name { get; set; }

        public string ClientSecretStr { get; set; }

        [JsonIgnore]
        public byte[]? ClientSecret { get; set; }

        [JsonIgnore]
        public byte[]? ClientSecretSalt { get; set; }

        public string ClientUrl { get; set; }

        public string LogoUrl { get; set; }

        public string LoginRedirectUrl { get; set; }

        public string LogoutRedirectUrl { get; set; }

        [JsonIgnore]
        public EntStatus Status => EntStatus.Active;

    }
}
