using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.UserRole;

namespace IdentityServer.Business.Validators.UserRole
{
    public class CreateIdentityUserRoleRequestValidator : AbstractValidator<CreateIdentityUserRoleRequest>
    {
        public CreateIdentityUserRoleRequestValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateIdentityUserRoleRequest.RoleId)));
            RuleFor(x => x.IdentityUserId).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateIdentityUserRoleRequest.IdentityUserId)));
        }
    }
}
