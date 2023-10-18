using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.Role
{
    public class CreateRoleRequest :CreateModel
    {
        public string Name { get; set; }
    }
}
