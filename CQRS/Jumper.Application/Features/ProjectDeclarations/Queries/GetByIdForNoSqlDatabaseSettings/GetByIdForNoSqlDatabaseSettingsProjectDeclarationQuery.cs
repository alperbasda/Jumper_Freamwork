using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForNoSqlDatabaseSettings;

public class GetByIdForNoSqlDatabaseSettingsProjectDeclarationQuery : IRequest<GetByIdForNoSqlDatabaseSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
