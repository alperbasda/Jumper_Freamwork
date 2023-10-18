using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.UserRole;

namespace IdentityServer.Business.Validators.UserRole
{
    public class UpdateIdentityUserRoleRequestValidator : AbstractValidator<UpdateIdentityUserRoleRequest>
    {
        public UpdateIdentityUserRoleRequestValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateIdentityUserRoleRequest.RoleId)));
            RuleFor(x => x.IdentityUserId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateIdentityUserRoleRequest.IdentityUserId)));
        }
    }
}
