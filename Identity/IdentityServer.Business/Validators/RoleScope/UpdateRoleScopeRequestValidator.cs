using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.RoleScope;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.RoleScope
{
    public class UpdateRoleScopeRequestValidator : AbstractValidator<UpdateRoleScopeRequest>
    {
        public UpdateRoleScopeRequestValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateRoleScopeRequest.OwnerId)));
            RuleFor(x => x.Scope).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateRoleScopeRequest.Scope)));
        }
    }
}
