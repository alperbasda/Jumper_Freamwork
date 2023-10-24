
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using FluentValidation;
namespace IdentityServer.Application.Features.AuthMessageses.Commands.Create;

public class CreateAuthMessagesCommandValidator : AbstractValidator<CreateAuthMessagesCommand>
{
    public CreateAuthMessagesCommandValidator()
    {
         
		RuleFor(w => w.Type).NotEmpty().NotNull().WithMessage("Lütfen Type Alanını Doldurun veya Seçin.");
		RuleFor(w => w.Code).NotEmpty().NotNull().WithMessage("Lütfen Code Alanını Doldurun veya Seçin.");
		RuleFor(w => w.LanguageCode).NotEmpty().NotNull().WithMessage("Lütfen LanguageCode Alanını Doldurun veya Seçin.");
		RuleFor(w => w.Message).NotEmpty().NotNull().WithMessage("Lütfen Message Alanını Doldurun veya Seçin.");

        
    }
}





