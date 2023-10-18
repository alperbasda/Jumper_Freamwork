using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.ApiResource
{
    public class UpdateApiResourceSecretRequest : UpdateModel
    {
        public string OldSecret { get; set; }

        public string NewSecret { get; set; }
    }
}
