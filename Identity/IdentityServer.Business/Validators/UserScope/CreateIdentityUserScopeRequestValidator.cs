using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.UserScopes;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.UserScope
{
    public class CreateIdentityUserScopeRequestValidator : AbstractValidator<CreateIdentityUserScopeRequest>
    {
        public CreateIdentityUserScopeRequestValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateIdentityUserScopeRequest.OwnerId)));
            RuleFor(x => x.Scope).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateIdentityUserScopeRequest.Scope)));
        }
    }
}
