using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.AuthMessage;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.AuthMessage
{
    public class UpdateAuthMessageRequestValidator : AbstractValidator<UpdateAuthMessageRequest>
    {
        public UpdateAuthMessageRequestValidator()
        {
            RuleFor(x => x.Message).Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(UpdateAuthMessageRequest.Message)));
            RuleFor(x => x.Type).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateAuthMessageRequest.Type)));
            RuleFor(x => x.LanguageCode).NotEmpty().NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateAuthMessageRequest.LanguageCode)));
            RuleFor(x => x.Code).NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(UpdateAuthMessageRequest.Code)));
        }
    }
}
