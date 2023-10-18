
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForLogSettings;

public class GetByIdForLogSettingsProjectDeclarationQuery : IRequest<GetByIdForLogSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
