using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.ApiResource;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.ApiResourceScope
{
    public class UpdateApiResourceScopeRequestValidator : AbstractValidator<UpdateApiResourceScopeRequest>
    {
        public UpdateApiResourceScopeRequestValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceScopeRequest.OwnerId)));
            RuleFor(x => x.Scope).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceScopeRequest.Scope)));
            RuleFor(x => x.Scope).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateApiResourceScopeRequest.Scope)));
            RuleFor(x => x.DisplayName).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceScopeRequest.DisplayName)));
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceScopeRequest.Description)));
        }
    }
}
