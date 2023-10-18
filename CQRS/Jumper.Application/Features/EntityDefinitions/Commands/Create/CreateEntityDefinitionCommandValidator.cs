using FluentValidation;

namespace Jumper.Application.Features.EntityDefinitions.Commands.Create;

public class CreateEntityDefinitionCommandValidator : AbstractValidator<CreateEntityDefinitionCommand>
{
    public CreateEntityDefinitionCommandValidator()
    {
        RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Ad Alanını Doldurun.");
    }
}
