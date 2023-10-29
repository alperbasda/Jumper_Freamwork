
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using FluentValidation;
namespace Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.BulkCreate;

public class BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommandValidator : AbstractValidator<BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand>
{
    public BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommandValidator()
    {
         
		RuleFor(w => w.EntityPropertyFeatureDefinitionId).NotEmpty().NotNull().WithMessage("Lütfen EntityPropertyFeatureDefinitionId Alanını Doldurun veya Seçin.");
		RuleFor(w => w.ProjectEntityPropertyId).NotEmpty().NotNull().WithMessage("Lütfen ProjectEntityPropertyId Alanını Doldurun veya Seçin.");

        
    }
}




