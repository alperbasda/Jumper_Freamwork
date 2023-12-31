
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.ClientScopes.Commands.BulkCreate;
using IdentityServer.Application.Features.ClientScopes.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;

using MediatR;
namespace IdentityServer.Application.Features.ClientScopes.Handlers.Commands.BulkCreate;

public class BulkCreateClientScopeCommandHandler : IRequestHandler<BulkCreateClientScopeWrapperCommand, List<BulkCreateClientScopeResponse>>
{
    private readonly IClientScopeDal _clientScopeDal;
    private readonly ClientScopeBusinessRules _clientScopeBusinessRules;
    private readonly IMapper _mapper;

    public BulkCreateClientScopeCommandHandler(IMapper mapper, IClientScopeDal clientScopeDal, ClientScopeBusinessRules clientScopeBusinessRules)
    {
        _mapper = mapper;
        _clientScopeDal = clientScopeDal;
        _clientScopeBusinessRules = clientScopeBusinessRules;
    }

    public async Task<List<BulkCreateClientScopeResponse>> Handle(BulkCreateClientScopeWrapperCommand request, CancellationToken cancellationToken)
    {
        var datas = _mapper.Map<List<ClientScope>>(request);

        _clientScopeBusinessRules.SetId(datas);
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _clientScopeDal.AddRangeAsync(datas);

        return _mapper.Map<List<BulkCreateClientScopeResponse>>(datas);
    }
}



