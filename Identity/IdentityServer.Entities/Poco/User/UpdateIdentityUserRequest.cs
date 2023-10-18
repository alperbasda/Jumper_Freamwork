using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.User
{
    public class UpdateIdentityUserRequest : UpdateModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName => string.IsNullOrEmpty(UserName) ? "" : UserName.ToLower();

        public string Email { get; set; }

        public string NormalizedEmail => string.IsNullOrEmpty(Email) ? "" : Email.ToLower();

        public string PhoneNumber { get; set; }

        public string ClientId { get; set; }

        public string? DeviceId { get; set; }

        public EntStatus Status { get; set; }
    }
}
