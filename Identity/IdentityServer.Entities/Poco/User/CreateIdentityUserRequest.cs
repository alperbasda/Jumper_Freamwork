using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;
using System.Text.Json.Serialization;

namespace IdentityServer.Entities.Poco.User
{
    public class CreateIdentityUserRequest : CreateModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName => string.IsNullOrEmpty(UserName) ? "" : UserName.ToLower();

        public string Email { get; set; }

        public string NormalizedEmail => string.IsNullOrEmpty(Email) ? "" : Email.ToLower();

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string ClientId { get; set; }

        public string? DeviceId { get; set; }

        [JsonIgnore]
        public EntStatus Status => EntStatus.Active;
    }
}
