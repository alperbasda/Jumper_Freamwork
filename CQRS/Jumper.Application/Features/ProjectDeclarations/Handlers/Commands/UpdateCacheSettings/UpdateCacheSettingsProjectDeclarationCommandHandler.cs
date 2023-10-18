using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateCacheSettings;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Commands.UpdateCacheSettings;

public class UpdateCacheSettingsProjectDeclarationCommandHandler : IRequestHandler<UpdateCacheSettingsProjectDeclarationCommand, UpdateCacheSettingsProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    IMapper _mapper;

    public UpdateCacheSettingsProjectDeclarationCommandHandler(IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IProjectDeclarationDal projectDeclarationDal)
    {
        _mapper = mapper;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _projectDeclarationDal = projectDeclarationDal;
    }


    public async Task<UpdateCacheSettingsProjectDeclarationResponse> Handle(UpdateCacheSettingsProjectDeclarationCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(project);

        _projectDeclarationBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(project!);

        _mapper.Map(request, project);

        await _projectDeclarationDal.UpdateAsync(project!);

        return _mapper.Map<UpdateCacheSettingsProjectDeclarationResponse>(project);
    }
}
