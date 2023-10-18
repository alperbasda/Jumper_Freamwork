using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdDirect;

public class GetByIdDirectProjectDeclarationQuery : IRequest<Domain.MongoEntities.ProjectDeclaration>
{
    public Guid Id { get; set; }

}
