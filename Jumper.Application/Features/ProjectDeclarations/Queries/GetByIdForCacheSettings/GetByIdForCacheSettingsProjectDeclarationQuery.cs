using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForCacheSettings;

public class GetByIdForCacheSettingsProjectDeclarationQuery : IRequest<GetByIdForCacheSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
