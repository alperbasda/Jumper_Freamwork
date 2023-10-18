using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Commands.Create;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Commands.Create;

public class CreateProjectDeclarationCommandHandler : IRequestHandler<CreateProjectDeclarationCommand, CreateProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    IMapper _mapper;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;

    public CreateProjectDeclarationCommandHandler(IProjectDeclarationDal projectDeclarationDal, IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _mapper = mapper;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
    }

    public async Task<CreateProjectDeclarationResponse> Handle(CreateProjectDeclarationCommand request, CancellationToken cancellationToken)
    {
        await _projectDeclarationBusinessRules.ThrowExceptionIfSamaNameProjectExists(request.Name);
        
        var data = _mapper.Map<Domain.MongoEntities.ProjectDeclaration>(request);
        
        _projectDeclarationBusinessRules.SetProjectStatusToPreparing(data);
        _projectDeclarationBusinessRules.SetUserId(data);
        
        var res = await _projectDeclarationDal.AddAsync(data);
        return _mapper.Map<CreateProjectDeclarationResponse>(res);
    }
}
