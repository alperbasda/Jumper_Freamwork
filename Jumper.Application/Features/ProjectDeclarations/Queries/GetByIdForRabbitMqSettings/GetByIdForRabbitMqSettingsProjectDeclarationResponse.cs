using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRabbitMqSettings;

public class GetByIdForRabbitMqSettingsProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public RabbitMqConfiguration? RabbitMqConfiguration { get; set; }
}
