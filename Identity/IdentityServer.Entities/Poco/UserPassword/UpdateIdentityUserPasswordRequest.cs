using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.UserPassword
{
    public class UpdateIdentityUserPasswordRequest : UserOwnedUpdateModel
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string NewPasswordConfirm { get; set; }
    }
}
