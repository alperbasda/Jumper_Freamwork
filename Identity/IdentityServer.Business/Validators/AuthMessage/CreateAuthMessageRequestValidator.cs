using FluentValidation;
using IdentityServer.Business.Extensions;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.AuthMessage;
using Tools.ObjectHelpers;

namespace IdentityServer.Business.Validators.AuthMessage
{
    public class CreateAuthMessageRequestValidator : AbstractValidator<CreateAuthMessageRequest>
    {
        public CreateAuthMessageRequestValidator()
        {
            RuleFor(x => x.Message).NotNull().NotEmpty().Must(StringHelper.NotNullAndNotContainSpace).WithMessage(InputError.NotNullNotContainSpace.Concat(nameof(CreateAuthMessageRequest.Message))).WithName("Mesaj");
            RuleFor(x => x.Type).NotNull().IsInEnum().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateAuthMessageRequest.Type)));
            RuleFor(x => x.LanguageCode).NotNull().IsInEnum().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateAuthMessageRequest.LanguageCode)));
            RuleFor(x => x.Code).NotNull().WithMessage(InputError.NullOrEmpty.Concat(nameof(CreateAuthMessageRequest.Code)));
        }

    }
}
