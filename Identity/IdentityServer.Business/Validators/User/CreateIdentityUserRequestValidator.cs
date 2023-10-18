using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.User;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.User
{
    public class CreateIdentityUserRequestValidator : AbstractValidator<CreateIdentityUserRequest>
    {
        public CreateIdentityUserRequestValidator()
        {
            RuleFor(x => x.UserName).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateIdentityUserRequest.UserName)));
            RuleFor(x => x.Email).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateIdentityUserRequest.Email)));
            RuleFor(x => x.Email).Must(StringHelper.IsValidMailAddress).WithMessage(InputError.InvalidEmail.Concat(nameof(CreateIdentityUserRequest.Email)));
            RuleFor(x => x.PhoneNumber).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateIdentityUserRequest.PhoneNumber)));
            RuleFor(x => x.PhoneNumber).Must(StringHelper.IsValidPhoneNumber).WithMessage(InputError.InvalidPhoneNumber.Concat(nameof(CreateIdentityUserRequest.PhoneNumber)));

        }
    }
}
