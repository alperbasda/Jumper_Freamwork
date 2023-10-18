using EntityBase.Enum;
using EntityBase.Poco.GetModelBase.Concrete;

namespace IdentityServer.Entities.Poco.User
{
    public class IdentityUserResponse : GetModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public string PhoneNumber { get; set; }

        public string ClientId { get; set; }

   //     public string? DeviceId { get; set; }

        public EntStatus Status { get; set; }
    }

}
