using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.Role
{
    public class UpdateRoleRequest : UpdateModel
    {
        public string Name { get; set; }
    }
}
