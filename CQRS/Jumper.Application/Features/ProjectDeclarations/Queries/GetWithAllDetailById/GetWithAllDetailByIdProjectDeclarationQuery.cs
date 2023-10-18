using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;

public class GetWithAllDetailByIdProjectDeclarationQuery : IRequest<GetWithAllDetailByIdProjectDeclarationResponse>
{
    public Guid Id { get; set; }

    public Guid ArchitectureId { get; set; }
}
