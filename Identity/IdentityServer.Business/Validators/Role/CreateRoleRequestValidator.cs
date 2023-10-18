using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Role;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.Role
{
    public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleRequestValidator()
        {
            RuleFor(x => x.Name).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateRoleRequest.Name)));
        }
    }
}
