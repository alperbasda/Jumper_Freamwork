using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Client;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.ClientScope
{
    public class UpdateClientScopeRequestValidator : AbstractValidator<UpdateClientScopeRequest>
    {
        public UpdateClientScopeRequestValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateClientScopeRequest.OwnerId)));
            RuleFor(x => x.Scope).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateClientScopeRequest.Scope)));
        }
    }
}
