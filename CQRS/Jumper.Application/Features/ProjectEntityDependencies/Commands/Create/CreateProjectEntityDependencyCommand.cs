using Core.Application.Pipelines.Transaction;
using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;

public class CreateProjectEntityDependencyCommand : IRequest<CreateProjectEntityDependencyResponse>, ITransactionalRequest
{
    private Guid _id = Guid.NewGuid();

    public Guid Id => _id;

    public Guid ProjectDeclarationId { get; set; }

    public Guid DependsOnId { get; set; }

    public Guid DependedId { get; set; }

    public EntityDependencyType EntityDependencyType { get; set; }
}
