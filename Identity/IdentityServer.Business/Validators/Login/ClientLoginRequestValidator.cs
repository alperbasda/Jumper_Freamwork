using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Login;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.Login
{
    public class ClientLoginRequestValidator : AbstractValidator<ClientLoginRequest>
    {
        public ClientLoginRequestValidator()
        {
            RuleFor(x => x.ClientId).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(ClientLoginRequest.ClientId)));
            RuleFor(x => x.ClientSecret).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(ClientLoginRequest.ClientSecret)));
        }
    }
}
