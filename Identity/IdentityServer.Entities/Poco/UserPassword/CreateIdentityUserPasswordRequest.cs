using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.UserPassword
{
    public class CreateIdentityUserPasswordRequest : UserOwnedCreateModel
    {
        public string NewPassword { get; set; }

        public string NewPasswordConfirm { get; set; }
    }
}
