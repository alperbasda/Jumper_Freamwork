using FluentValidation;

namespace Jumper.Application.Features.EntityDefinitions.Commands.Update;

public class UpdateEntityDefinitionCommandValidator : AbstractValidator<UpdateEntityDefinitionCommand>
{
    public UpdateEntityDefinitionCommandValidator()
    {
        RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Ad Alanını Doldurun.");
    }
}
