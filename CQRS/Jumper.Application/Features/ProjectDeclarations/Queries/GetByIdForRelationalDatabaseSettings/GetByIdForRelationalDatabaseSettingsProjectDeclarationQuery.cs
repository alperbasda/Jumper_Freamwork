using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRelationalDatabaseSettings;

public class GetByIdForRelationalDatabaseSettingsProjectDeclarationQuery : IRequest<GetByIdForRelationalDatabaseSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
