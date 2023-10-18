using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdAllData;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetByIdAllData;

public class GetByIdAllDataProjectDeclarationQueryHandler : IRequestHandler<GetByIdAllDataProjectDeclarationQuery, GetByIdAllDataProjectDeclarationResponse>
{
    private readonly IProjectDeclarationDal _projectDeclarationDal;
    private readonly ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAllDataProjectDeclarationQueryHandler(IProjectDeclarationDal projectDeclarationDal, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IMapper mapper)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAllDataProjectDeclarationResponse> Handle(GetByIdAllDataProjectDeclarationQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(data);

        return _mapper.Map<GetByIdAllDataProjectDeclarationResponse>(data);
    }
}
