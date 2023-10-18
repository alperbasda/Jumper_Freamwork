using FluentValidation;

namespace Jumper.Application.Features.ProjectEntities.Commands.CreateFromDefinition;

public class CreateFromDefinitionProjectEntityCommandValidator : AbstractValidator<CreateFromDefinitionProjectEntityCommand>
{
    public CreateFromDefinitionProjectEntityCommandValidator()
    {
        RuleFor(w => w.EntityDefinitionId).NotEmpty().NotNull().WithMessage("Lütfen Nesne Seçin.");
        RuleFor(w => w.DatabaseType).NotNull().WithMessage("Lütfen Veritabanı Tipi Seçin.");
        RuleFor(w => w.ProjectDeclarationId).NotEmpty().NotNull().WithMessage("Lütfen Sayfayı Yenileyin.");

    }
}
