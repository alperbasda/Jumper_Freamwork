using FluentValidation;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Commands.Create
{
    public class CreateEntityPropertyDefinitionValidator : AbstractValidator<CreateEntityPropertyDefinitionCommand>
    {
        public CreateEntityPropertyDefinitionValidator()
        {
            RuleFor(w => w.EntityDefinitionId).NotEmpty().NotNull().WithMessage("Lütfen Sayfayı Yenileyin");
            RuleFor(w => w.PropertyTypeCode).NotEmpty().NotNull().WithMessage("Lütfen Özellik Tipi Seçin");
            RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage("Lütfen Özellik Adı Girin");
        }
    }
}
