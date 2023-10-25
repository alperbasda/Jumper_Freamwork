using FluentValidation;

namespace Jumper.Application.Features.ProjectEntityProperties.Commands.Create;

public class CreateProjectEntityPropertyCommandValidator : AbstractValidator<CreateProjectEntityPropertyCommand>
{
    public CreateProjectEntityPropertyCommandValidator()
    {
        RuleFor(w => w.ProjectEntityId).NotNull().NotEmpty().WithMessage("Lütfen Nesne Seçin");
        RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Özellik Adı Girin.");
        RuleFor(w => w.PropertyTypeCode).NotEmpty().NotNull().WithMessage("Lütfen Tip Seçin.");
        RuleFor(w => w.HasIndex).NotNull().WithMessage("Lütfen Index Durumu Seçin.");
        RuleFor(w => w.IsUnique).NotNull().WithMessage("Lütfen Benzersizlik Durumu Seçin.");
        RuleFor(w => w.PropertyInputTypeCode).NotEmpty().NotNull().WithMessage("Lütfen Girdi Tipi Doldurun.");
    }
}
