using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;
using System.Text.Json.Serialization;

namespace IdentityServer.Entities.Poco.ApiResource
{
    public class CreateApiResourceRequest : CreateModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string ApiSecretStr { get; set; }

        [JsonIgnore]
        public byte[]? ApiSecret { get; set; }

        [JsonIgnore]
        public byte[]? ApiSecretSalt { get; set; }

        [JsonIgnore]
        public EntStatus Status => EntStatus.Active;

    }
}
