using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.RoleScope;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.RoleScope
{
    public class CreateRoleScopeRequestValidator : AbstractValidator<CreateRoleScopeRequest>
    {
        public CreateRoleScopeRequestValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateRoleScopeRequest.OwnerId)));
            RuleFor(x => x.Scope).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateRoleScopeRequest.Scope)));
        }
    }
}
