using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;
using System.Text.Json.Serialization;

namespace IdentityServer.Entities.Poco.ApiResource
{
    public class UpdateApiResourceRequest : UpdateModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public EntStatus Status { get; set; }

        [JsonIgnore]
        public byte[]? ApiSecret { get; set; }

        [JsonIgnore]
        public byte[]? ApiSecretSalt { get; set; }
    }
}
