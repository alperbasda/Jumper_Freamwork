using AutoMapper;
using Jumper.Application.Features.ProjectEntities.Commands.Update;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Commands.Update;

public class UpdateProjectEntityCommandHandler : IRequestHandler<UpdateProjectEntityCommand, UpdateProjectEntityResponse>
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly ProjectEntityBusinessRules _projectEntityBusinessRules;
    private readonly IMapper _mapper;

    public UpdateProjectEntityCommandHandler(IMapper mapper, ProjectEntityBusinessRules projectEntityBusinessRules, IProjectEntityDal projectEntityDal)
    {
        _mapper = mapper;
        _projectEntityBusinessRules = projectEntityBusinessRules;
        _projectEntityDal = projectEntityDal;
    }

    public async Task<UpdateProjectEntityResponse> Handle(UpdateProjectEntityCommand request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityDal.GetAsync(w => w.Id == request.Id);

        await _projectEntityBusinessRules.ThrowExceptionIfDataNull(data);
        _projectEntityBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(data!);
        await _projectEntityBusinessRules.ThrowExceptionIfSamaNameProjectEntityExistsForUpdate(data!.ProjectDeclarationId,request.Name,request.Id);
        _projectEntityBusinessRules.ThrowExceptionEntityIsConstant(data!);

        _mapper.Map(request, data);

        await _projectEntityDal.UpdateAsync(data);

        return _mapper.Map<UpdateProjectEntityResponse>(data);
    }
}
