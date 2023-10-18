using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;
using System.Text.Json.Serialization;

namespace IdentityServer.Entities.Poco.ClientApiResource
{
    public class CreateClientApiResourceRequest : CreateModel
    {
        public Guid ClientId { get; set; }

        public Guid ApiResourceId { get; set; }
    }
}
