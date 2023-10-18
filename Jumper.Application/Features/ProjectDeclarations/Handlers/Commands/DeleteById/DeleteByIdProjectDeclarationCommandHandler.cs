using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Commands.DeleteById;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Commands.DeleteById;

public class DeleteByIdProjectDeclarationCommandHandler : IRequestHandler<DeleteByIdProjectDeclarationCommand, DeleteByIdProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    IMapper _mapper;

    public DeleteByIdProjectDeclarationCommandHandler(IProjectDeclarationDal projectDeclarationDal, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IMapper mapper)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteByIdProjectDeclarationResponse> Handle(DeleteByIdProjectDeclarationCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);
        
        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(project);

        _projectDeclarationBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(project!);

        return _mapper.Map<DeleteByIdProjectDeclarationResponse>(await _projectDeclarationDal.DeleteAsync(project!));
    }
}
