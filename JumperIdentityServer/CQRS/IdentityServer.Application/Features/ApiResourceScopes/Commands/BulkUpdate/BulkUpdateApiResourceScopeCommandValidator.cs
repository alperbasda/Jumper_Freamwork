
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using FluentValidation;
namespace IdentityServer.Application.Features.ApiResourceScopes.Commands.BulkUpdate;

public class BulkUpdateApiResourceScopeCommandValidator : AbstractValidator<BulkUpdateApiResourceScopeCommand>
{
    public BulkUpdateApiResourceScopeCommandValidator()
    {
         
		RuleFor(w => w.DisplayName).NotEmpty().NotNull().WithMessage("Lütfen DisplayName Alanını Doldurun veya Seçin.");
		RuleFor(w => w.Scope).NotEmpty().NotNull().WithMessage("Lütfen Scope Alanını Doldurun veya Seçin.");
		RuleFor(w => w.Description).NotEmpty().NotNull().WithMessage("Lütfen Description Alanını Doldurun veya Seçin.");

        
    }
}




