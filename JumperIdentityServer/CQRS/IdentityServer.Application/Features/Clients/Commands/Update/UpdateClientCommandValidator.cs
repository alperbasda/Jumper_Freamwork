
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using FluentValidation;
namespace IdentityServer.Application.Features.Clients.Commands.Update;

public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidator()
    {
         
		RuleFor(w => w.ClientSecret).NotEmpty().NotNull().WithMessage("Lütfen ClientSecret Alanını Doldurun veya Seçin.");
		RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Name Alanını Doldurun veya Seçin.");
		RuleFor(w => w.Status).NotEmpty().NotNull().WithMessage("Lütfen Status Alanını Doldurun veya Seçin.");
		RuleFor(w => w.ClientSecretSalt).NotEmpty().NotNull().WithMessage("Lütfen ClientSecretSalt Alanını Doldurun veya Seçin.");

        
    }
}




