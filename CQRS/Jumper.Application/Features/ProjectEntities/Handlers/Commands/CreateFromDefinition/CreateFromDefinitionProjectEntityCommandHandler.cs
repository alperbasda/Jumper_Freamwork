using AutoMapper;
using Jumper.Application.Features.ProjectEntities.Commands.CreateFromDefinition;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Commands.CreateFromDefinition;

public class CreateFromDefinitionProjectEntityCommandHandler : IRequestHandler<CreateFromDefinitionProjectEntityCommand, CreateFromDefinitionProjectEntityResponse>
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly ProjectEntityBusinessRules _projectEntityBusinessRules;
    private readonly IMapper _mapper;

    public CreateFromDefinitionProjectEntityCommandHandler(IMapper mapper, ProjectEntityBusinessRules projectEntityBusinessRules, IProjectEntityDal projectEntityDal)
    {
        _mapper = mapper;
        _projectEntityBusinessRules = projectEntityBusinessRules;
        _projectEntityDal = projectEntityDal;
    }

    public async Task<CreateFromDefinitionProjectEntityResponse> Handle(CreateFromDefinitionProjectEntityCommand request, CancellationToken cancellationToken)
    {
        await _projectEntityBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(request.ProjectDeclarationId);

        var entityDefinition = await _projectEntityBusinessRules.GetDefinitionWithProperties(request.EntityDefinitionId);

        await _projectEntityBusinessRules.ThrowExceptionIfSamaNameProjectEntityExists(request.ProjectDeclarationId, entityDefinition.Name);

        var projectEntity = _mapper.Map<ProjectEntity>(entityDefinition);

        _mapper.Map(request, projectEntity);

        _projectEntityBusinessRules.SetUserId(projectEntity);
        
        _projectEntityBusinessRules.SetIds(projectEntity);
        
        await _projectEntityDal.AddAsync(projectEntity);

        return _mapper.Map<CreateFromDefinitionProjectEntityResponse>(projectEntity);

    }
}
