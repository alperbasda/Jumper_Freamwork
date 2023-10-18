using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.UserPassword;
using System.Text.RegularExpressions;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.UserPassword
{
    public class UpdateIdentityUserPasswordRequestValidator : AbstractValidator<UpdateIdentityUserPasswordRequest>
    {
        public UpdateIdentityUserPasswordRequestValidator()
        {
            RuleFor(x => x.OldPassword).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateIdentityUserPasswordRequest.OldPassword)));
            RuleFor(x => x.NewPassword).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateIdentityUserPasswordRequest.NewPassword)));
            RuleFor(x => x.NewPasswordConfirm).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateIdentityUserPasswordRequest.NewPasswordConfirm)));
            RuleFor(x => x).Must(ComparePasswords).WithMessage(InputError.NotSameValue.Concat(nameof(UpdateIdentityUserPasswordRequest.NewPassword)));
            RuleFor(x => x.NewPassword).Must(ValidatePasswordRequirement).WithMessage(InputError.InvalidPasswordRequirement.Concat(nameof(UpdateIdentityUserPasswordRequest.NewPassword)));
        }
        
        
        private bool ComparePasswords(UpdateIdentityUserPasswordRequest request)
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
