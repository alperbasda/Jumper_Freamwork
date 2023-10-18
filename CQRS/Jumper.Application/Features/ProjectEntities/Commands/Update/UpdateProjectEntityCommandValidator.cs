using FluentValidation;

namespace Jumper.Application.Features.ProjectEntities.Commands.Update;

public class UpdateProjectEntityCommandValidator : AbstractValidator<UpdateProjectEntityCommand>
{
    public UpdateProjectEntityCommandValidator()
    {
        RuleFor(w => w.Id).NotEmpty().NotNull().WithMessage("Lütfen Sayfayı Yenileyin.");
        RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Nesne Adı Girin.");
        RuleFor(w => w.DatabaseType).NotNull().WithMessage("Lütfen Veri Tabanı Tipi Seçin.");
    }
}
