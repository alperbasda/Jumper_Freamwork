using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Client;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.Client
{
    public class UpdateClientRequestValidator : AbstractValidator<UpdateClientRequest>
    {
        public UpdateClientRequestValidator()
        {
            RuleFor(x => x.ClientId).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateClientRequest.ClientId)));
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateClientRequest.Name)));
            RuleFor(x => x.ClientSecretStr).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateClientRequest.ClientSecretStr)));
            RuleFor(x => x.Status).NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateClientRequest.Status)));
        }
    }
}
