
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.ApiResourceScopes.Commands.DeleteById;
using IdentityServer.Application.Features.ApiResourceScopes.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.ApiResourceScopes.Handlers.Commands.DeleteById;

public class DeleteByIdApiResourceScopeCommandHandler : IRequestHandler<DeleteByIdApiResourceScopeCommand, DeleteByIdApiResourceScopeResponse>
{
    private readonly IApiResourceScopeDal _apiResourceScopeDal;
    private readonly ApiResourceScopeBusinessRules _apiResourceScopeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdApiResourceScopeCommandHandler(IMapper mapper, IApiResourceScopeDal apiResourceScopeDal, ApiResourceScopeBusinessRules apiResourceScopeBusinessRules)
    {
        _mapper = mapper;
        _apiResourceScopeDal = apiResourceScopeDal;
        _apiResourceScopeBusinessRules = apiResourceScopeBusinessRules;
    }

    public async Task<DeleteByIdApiResourceScopeResponse> Handle(DeleteByIdApiResourceScopeCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _apiResourceScopeDal.GetAsync(w => w.Id == request.Id);
            
        _apiResourceScopeBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _apiResourceScopeDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdApiResourceScopeResponse>(data);
    }
}



