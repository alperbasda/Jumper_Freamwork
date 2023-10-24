
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using FluentValidation;
namespace IdentityServer.Application.Features.ClientUserRelations.Commands.Create;

public class CreateClientUserRelationCommandValidator : AbstractValidator<CreateClientUserRelationCommand>
{
    public CreateClientUserRelationCommandValidator()
    {
         
		RuleFor(w => w.ClientId).NotEmpty().NotNull().WithMessage("Lütfen ClientId Alanını Doldurun veya Seçin.");
		RuleFor(w => w.UserId).NotEmpty().NotNull().WithMessage("Lütfen UserId Alanını Doldurun veya Seçin.");

        
    }
}




