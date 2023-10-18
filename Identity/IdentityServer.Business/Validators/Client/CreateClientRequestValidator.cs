using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Client;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.Client
{
    public class CreateClientRequestValidator: AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(x => x.ClientId).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateClientRequest.ClientId)));
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateClientRequest.Name)));
            RuleFor(x => x.ClientSecretStr).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateClientRequest.ClientSecretStr)));
        }
    }
}
