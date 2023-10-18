using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.ApiResource;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.ApiResource
{
    public class UpdateApiResourceRequestValidator : AbstractValidator<UpdateApiResourceRequest>
    {
        public UpdateApiResourceRequestValidator()
        {
            RuleFor(x => x.Name).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateApiResourceRequest.Name)));
            RuleFor(x => x.DisplayName).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceRequest.DisplayName)));
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceRequest.Description)));
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateApiResourceRequest.Status)));
        }
    }
}
