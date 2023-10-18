using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.UserScopes;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.UserScope
{
    public class UpdateIdentityUserScopeRequestValidator : AbstractValidator<UpdateIdentityUserScopeRequest>
    {
        public UpdateIdentityUserScopeRequestValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateIdentityUserScopeRequest.OwnerId)));
            RuleFor(x => x.Scope).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateIdentityUserScopeRequest.Scope)));
            RuleFor(x => x.Scope).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateIdentityUserScopeRequest.Scope)));
        }
    }
}
