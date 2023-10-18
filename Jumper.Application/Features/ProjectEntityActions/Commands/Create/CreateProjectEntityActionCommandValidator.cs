using FluentValidation;

namespace Jumper.Application.Features.ProjectEntityActions.Commands.Create
{
    public class CreateProjectEntityActionCommandValidator : AbstractValidator<CreateProjectEntityActionCommand>
    {
        public CreateProjectEntityActionCommandValidator()
        {
            RuleFor(w => w.Name).NotNull().NotEmpty().WithMessage("Lütfen Command Adı Girin");
            RuleFor(w => w.ProjectDeclarationRef).NotNull().NotEmpty().WithMessage("Lütfen Sayfayı Yenileyin");
            RuleFor(w => w.ProjectEntityId).NotNull().NotEmpty().WithMessage("Lütfen Nesne Seçin");
            RuleFor(w => w.CacheEnabled).NotNull().WithMessage("Lütfen Cache Durumu Seçin");
            RuleFor(w => w.LogEnabled).NotNull().WithMessage("Lütfen Log Durumu Seçin");
            RuleFor(w => w.EntityAction).NotNull().WithMessage("Lütfen İstek Tipini Seçin");
        }
    }
}
