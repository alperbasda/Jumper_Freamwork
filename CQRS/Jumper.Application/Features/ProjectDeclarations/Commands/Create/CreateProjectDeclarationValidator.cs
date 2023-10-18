using FluentValidation;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.Create
{
    public class CreateProjectDeclarationValidator : AbstractValidator<CreateProjectDeclarationCommand>
    {
        public CreateProjectDeclarationValidator()
        {
            RuleFor(w => w.Name).NotEmpty().WithMessage("Lütfen Proje Adı Girin.");
            RuleFor(w => w.Description).NotEmpty().WithMessage("Lütfen Proje Açıklaması Girin.");

        }
    }
}
