using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.ApiResource;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.ApiResource
{
    public class UpdateApiResourceSecretRequestValidator : AbstractValidator<UpdateApiResourceSecretRequest>
    {
        public UpdateApiResourceSecretRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceSecretRequest.Id)));
            RuleFor(x => x.NewSecret).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateApiResourceSecretRequest.NewSecret)));
            RuleFor(x => x.OldSecret).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateApiResourceSecretRequest.OldSecret)));
        }
    }
}
