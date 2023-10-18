using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRabbitMqSettings;

public class GetByIdForRabbitMqSettingsProjectDeclarationQuery : IRequest<GetByIdForRabbitMqSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
