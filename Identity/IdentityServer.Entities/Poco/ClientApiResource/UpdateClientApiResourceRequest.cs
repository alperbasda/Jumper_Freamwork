using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.ClientApiResource
{
    public class UpdateClientApiResourceRequest : UpdateModel
    {
        public Guid ClientId { get; set; }

        public Guid ApiResourceId { get; set; }
    }
}
