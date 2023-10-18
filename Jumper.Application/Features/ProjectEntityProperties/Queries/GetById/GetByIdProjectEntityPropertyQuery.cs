using MediatR;

namespace Jumper.Application.Features.ProjectEntityProperties.Queries.GetById;

public class GetByIdProjectEntityPropertyQuery : IRequest<GetByIdProjectEntityPropertyResponse>
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationRef { get; set; }

}
