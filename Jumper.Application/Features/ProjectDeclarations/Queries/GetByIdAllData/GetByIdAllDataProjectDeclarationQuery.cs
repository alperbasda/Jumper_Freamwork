using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdAllData;

public class GetByIdAllDataProjectDeclarationQuery : IRequest<GetByIdAllDataProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
