using MediatR;


namespace Jumper.Application.Features.ProjectDeclarations.Commands.DeleteById;

public class DeleteByIdProjectDeclarationCommand : IRequest<DeleteByIdProjectDeclarationResponse>
{
    public Guid Id { get; set; }
}
