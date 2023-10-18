using FluentValidation;


namespace Jumper.Application.Features.ProjectEntityActionProperties.Commands.Create;

public class CreateProjectEntityActionPropertyCommandValidator : AbstractValidator<CreateProjectEntityActionPropertyCommand>
{
    public CreateProjectEntityActionPropertyCommandValidator()
    {
        RuleFor(w => w.ActionPropertyType).NotNull().WithMessage("Lütfen Aksiyon Tipi Seçin");
        RuleFor(w => w.ProjectDeclarationRef).NotNull().WithMessage("Lütfen Sayfayı Yenileyin");
        RuleFor(w => w.ProjectEntityActionId).NotNull().WithMessage("Lütfen Sayfayı Yenileyin");
        RuleFor(w => w.Name).NotNull().WithMessage("Lütfen Aksiyon Adı Girin");
    }

}
