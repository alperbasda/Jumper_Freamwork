using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateInfo;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Commands.UpdateInfo;

public class UpdateInfoProjectDeclarationCommandHandler : IRequestHandler<UpdateInfoProjectDeclarationCommand, UpdateInfoProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    IMapper _mapper;

    public UpdateInfoProjectDeclarationCommandHandler(IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IProjectDeclarationDal projectDeclarationDal)
    {
        _mapper = mapper;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _projectDeclarationDal = projectDeclarationDal;
    }

    public async Task<UpdateInfoProjectDeclarationResponse> Handle(UpdateInfoProjectDeclarationCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(project);

        _projectDeclarationBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(project!);

        _mapper.Map(request,project);

        await _projectDeclarationDal.UpdateAsync(project!);

        return _mapper.Map<UpdateInfoProjectDeclarationResponse>(project);
    }
}
