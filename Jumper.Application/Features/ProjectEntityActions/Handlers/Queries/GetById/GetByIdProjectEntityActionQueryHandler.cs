using AutoMapper;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetById;
using Jumper.Application.Features.ProjectEntityActions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Handlers.Queries.GetById;

public class GetByIdProjectEntityActionQueryHandler : IRequestHandler<GetByIdProjectEntityActionQuery, GetByIdProjectEntityActionResponse>
{
    private readonly IProjectEntityActionDal _projectEntityActionDal;
    private readonly ProjectEntityActionBusinessRules _projectEntityActionBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdProjectEntityActionQueryHandler(IMapper mapper, ProjectEntityActionBusinessRules projectEntityCommandBusinessRules, IProjectEntityActionDal projectEntityActionDal)
    {
        _mapper = mapper;
        _projectEntityActionBusinessRules = projectEntityCommandBusinessRules;
        _projectEntityActionDal = projectEntityActionDal;
    }


    public async Task<GetByIdProjectEntityActionResponse> Handle(GetByIdProjectEntityActionQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityActionDal.GetAsync(w => w.Id == request.Id);
        await _projectEntityActionBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(request.ProjectDeclarationRef, data!.ProjectEntityId);

        return _mapper.Map<GetByIdProjectEntityActionResponse>(data);
    }
}
