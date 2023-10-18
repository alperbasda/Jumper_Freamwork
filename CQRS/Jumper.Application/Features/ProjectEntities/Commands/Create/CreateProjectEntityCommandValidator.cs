using FluentValidation;

namespace Jumper.Application.Features.ProjectEntities.Commands.Create;

public class CreateProjectEntityCommandValidator : AbstractValidator<CreateProjectEntityCommand>
{
    public CreateProjectEntityCommandValidator()
    {
        RuleFor(w => w.ProjectDeclarationId).NotEmpty().NotNull().WithMessage("Lütfen Sayfayı Yenileyin.");
        RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Nesne Adı Girin.");
        RuleFor(w => w.DatabaseType).NotNull().WithMessage("Lütfen Veri Tabanı Tipi Seçin.");
    }
}
