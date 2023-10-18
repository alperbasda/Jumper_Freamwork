using AutoMapper;
using Jumper.Application.Features.ProjectEntityProperties.Commands.Create;
using Jumper.Application.Features.ProjectEntityProperties.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Commands.Create;

public class CreateProjectEntityPropertyCommandHandler : IRequestHandler<CreateProjectEntityPropertyCommand, CreateProjectEntityPropertyResponse>
{
    private readonly IProjectEntityPropertyDal _projectEntityPropertyDal;
    private readonly ProjectEntityPropertyBusinessRules _projectEntityPropertyBusinessRules;
    private readonly IMapper _mapper;
    public CreateProjectEntityPropertyCommandHandler(IMapper mapper, ProjectEntityPropertyBusinessRules ProjectEntityPropertyBusinessRules, IProjectEntityPropertyDal projectEntityPropertyDal)
    {
        _mapper = mapper;
        _projectEntityPropertyBusinessRules = ProjectEntityPropertyBusinessRules;
        _projectEntityPropertyDal = projectEntityPropertyDal;
    }

    public async Task<CreateProjectEntityPropertyResponse> Handle(CreateProjectEntityPropertyCommand request, CancellationToken cancellationToken)
    {
        await _projectEntityPropertyBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(request.ProjectDeclarationRef, request.ProjectEntityId);

        var data = _mapper.Map<ProjectEntityProperty>(request);
        await _projectEntityPropertyDal.AddAsync(data);
        return _mapper.Map<CreateProjectEntityPropertyResponse>(data);
    }
}
