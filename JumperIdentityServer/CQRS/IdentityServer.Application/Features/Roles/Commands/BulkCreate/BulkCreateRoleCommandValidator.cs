
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using FluentValidation;
namespace IdentityServer.Application.Features.Roles.Commands.BulkCreate;

public class BulkCreateRoleCommandValidator : AbstractValidator<BulkCreateRoleCommand>
{
    public BulkCreateRoleCommandValidator()
    {
         
		RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Name Alanını Doldurun veya Seçin.");

        
    }
}





