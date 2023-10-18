using EntityBase.Poco.GetModelBase.Concrete;
using System.Text.Json.Serialization;

namespace IdentityServer.Entities.Poco.ApiResource
{
    public class ApiResourceResponse : GetModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public byte[] ApiSecret { get; set; }

        [JsonIgnore]
        public byte[] ApiSecretSalt { get; set; }

        public List<ApiResourceScopeResponse> ApiResourceScopes { get; set; }
    }
}
