using FluentValidation;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.ApiResource;
using IdentityServer.Business.Extensions;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.ApiResource
{
    public class CreateApiResourceRequestValidator : AbstractValidator<CreateApiResourceRequest>
    {
        public CreateApiResourceRequestValidator()
        {
            RuleFor(x => x.Name).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateApiResourceRequest.Name)));
            RuleFor(x => x.DisplayName).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateApiResourceRequest.DisplayName)));
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateApiResourceRequest.Description)));
            RuleFor(x => x.ApiSecretStr).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateApiResourceRequest.ApiSecretStr)));
        }
    }
}
