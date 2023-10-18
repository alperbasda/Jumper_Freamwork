using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Login;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.Login
{
    public class RefreshTokenLoginRequestValidator : AbstractValidator<RefreshTokenLoginRequest>
    {
        public RefreshTokenLoginRequestValidator()
        {
            RuleFor(x => x.RefreshToken).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(RefreshTokenLoginRequest.RefreshToken)));
        }
    }
}
