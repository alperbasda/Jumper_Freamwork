using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Login;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.Login
{
    public class WebLoginRequestValidator : AbstractValidator<WebLoginRequest>
    {
        public WebLoginRequestValidator()
        {
            RuleFor(x => x.UserName).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(WebLoginRequest.UserName)));
            RuleFor(x => x.Password).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(WebLoginRequest.Password)));
        }
    }
}
