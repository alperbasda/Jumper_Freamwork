using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.ApiResource;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.ApiResourceScope
{
    public class CreateApiResourceScopeRequestValidator : AbstractValidator<CreateApiResourceScopeRequest>
    {
        public CreateApiResourceScopeRequestValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateApiResourceScopeRequest.OwnerId)));
            RuleFor(x => x.Scope).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateApiResourceScopeRequest.Scope)));
            RuleFor(x => x.DisplayName).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateApiResourceScopeRequest.DisplayName)));
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateApiResourceScopeRequest.Description)));
        }
    }
}
