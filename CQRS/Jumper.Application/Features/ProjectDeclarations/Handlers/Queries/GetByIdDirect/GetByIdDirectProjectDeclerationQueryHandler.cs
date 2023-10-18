using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdDirect;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetByIdDirect;

public class GetByIdDirectProjectDeclerationQueryHandler : IRequestHandler<GetByIdDirectProjectDeclarationQuery, Domain.MongoEntities.ProjectDeclaration>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;

    public GetByIdDirectProjectDeclerationQueryHandler(IProjectDeclarationDal projectDeclarationDal, ProjectDeclarationBusinessRules projectDeclarationBusinessRules)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
    }

    public async Task<Domain.MongoEntities.ProjectDeclaration> Handle(GetByIdDirectProjectDeclarationQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id);
        
        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(data);
        
        return data!;
    }
}
