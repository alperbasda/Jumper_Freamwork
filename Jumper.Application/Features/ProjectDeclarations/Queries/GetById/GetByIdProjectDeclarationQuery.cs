using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetById;

public class GetByIdProjectDeclarationQuery : IRequest<GetByIdProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
