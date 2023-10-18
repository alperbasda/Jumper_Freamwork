using AutoMapper;
using Jumper.Application.Features.ProjectEntities.Commands.Create;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Commands.Create;

public class CreateProjectEntityCommandHandler : IRequestHandler<CreateProjectEntityCommand, CreateProjectEntityResponse>
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly ProjectEntityBusinessRules _projectEntityBusinessRules;
    private readonly IMapper _mapper;

    public CreateProjectEntityCommandHandler(IMapper mapper, ProjectEntityBusinessRules projectEntityBusinessRules, IProjectEntityDal projectEntityDal)
    {
        _mapper = mapper;
        _projectEntityBusinessRules = projectEntityBusinessRules;
        _projectEntityDal = projectEntityDal;
    }

    public async Task<CreateProjectEntityResponse> Handle(CreateProjectEntityCommand request, CancellationToken cancellationToken)
    {
        await _projectEntityBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(request.ProjectDeclarationId);
        await _projectEntityBusinessRules.ThrowExceptionIfSamaNameProjectEntityExists(request.ProjectDeclarationId,request.Name);
        
        var data = _mapper.Map<ProjectEntity>(request);

        _projectEntityBusinessRules.SetUserId(data);

        _projectEntityBusinessRules.AddDefaultProperties(data);
        _projectEntityBusinessRules.SetIds(data);

        await _projectEntityDal.AddAsync(data);

        return _mapper.Map<CreateProjectEntityResponse>(data);
    }
}
