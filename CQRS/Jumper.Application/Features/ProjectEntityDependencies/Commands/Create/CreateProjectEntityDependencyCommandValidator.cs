using FluentValidation;

namespace Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;

public class CreateProjectEntityDependencyCommandValidator : AbstractValidator<CreateProjectEntityDependencyCommand>
{
    public CreateProjectEntityDependencyCommandValidator()
    {
        RuleFor(w => w.EntityDependencyType).NotNull().WithMessage("Lütfen İlişki Tipi Seçin.");
        RuleFor(w => w.DependsOnId).NotNull().WithMessage("Lütfen Nesne Seçin.");
        RuleFor(w => w.DependedId).NotNull().WithMessage("Lütfen Nesne Seçin.");

    }
}
