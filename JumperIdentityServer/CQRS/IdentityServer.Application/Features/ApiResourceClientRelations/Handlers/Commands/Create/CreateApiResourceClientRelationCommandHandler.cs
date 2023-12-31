
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.ApiResourceClientRelations.Commands.Create;
using IdentityServer.Application.Features.ApiResourceClientRelations.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.ApiResourceClientRelations.Handlers.Commands.Create;

public class CreateApiResourceClientRelationCommandHandler : IRequestHandler<CreateApiResourceClientRelationCommand, CreateApiResourceClientRelationResponse>
{
    private readonly IApiResourceClientRelationDal _apiResourceClientRelationDal;
    private readonly ApiResourceClientRelationBusinessRules _apiResourceClientRelationBusinessRules;
    private readonly IMapper _mapper;

    public CreateApiResourceClientRelationCommandHandler(IMapper mapper, IApiResourceClientRelationDal apiResourceClientRelationDal, ApiResourceClientRelationBusinessRules apiResourceClientRelationBusinessRules)
    {
        _mapper = mapper;
        _apiResourceClientRelationDal = apiResourceClientRelationDal;
        _apiResourceClientRelationBusinessRules = apiResourceClientRelationBusinessRules;
    }

    public async Task<CreateApiResourceClientRelationResponse> Handle(CreateApiResourceClientRelationCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<ApiResourceClientRelation>(request);

        _apiResourceClientRelationBusinessRules.SetId(data);
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _apiResourceClientRelationDal.AddAsync(data);

        return _mapper.Map<CreateApiResourceClientRelationResponse>(data);
    }
}



