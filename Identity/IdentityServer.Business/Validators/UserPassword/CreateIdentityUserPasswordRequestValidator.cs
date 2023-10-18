using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.UserPassword;
using System.Text.RegularExpressions;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.UserPassword
{
    public class CreateIdentityUserPasswordRequestValidator : AbstractValidator<CreateIdentityUserPasswordRequest>
    {
        public CreateIdentityUserPasswordRequestValidator()
        {
            RuleFor(x => x.NewPasswordConfirm).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateIdentityUserPasswordRequest.NewPasswordConfirm)));
            RuleFor(x => x.NewPassword).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateIdentityUserPasswordRequest.NewPassword)));
            RuleFor(x => x.NewPasswordConfirm).Must(StringHelper.NotContainSpace).WithMessage(InputError.NotContainSpace.Concat(nameof(CreateIdentityUserPasswordRequest.NewPasswordConfirm)));
            RuleFor(x => x).Must(ComparePasswords).WithMessage(InputError.NotSameValue.Concat(nameof(CreateIdentityUserPasswordRequest.NewPassword)));
            RuleFor(x => x.NewPassword).Must(ValidatePasswordRequirement).WithMessage(InputError.InvalidPasswordRequirement.Concat(nameof(CreateIdentityUserPasswordRequest.NewPassword)));
        }

        private bool ComparePasswords(CreateIdentityUserPasswordRequest request)
        {
            return request.NewPassword == request.NewPasswordConfirm;
        }

        private bool ValidatePasswordRequirement(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimumChars = new Regex(@".{5,}");
            return hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimumChars.IsMatch(input);
        }
    }
}
