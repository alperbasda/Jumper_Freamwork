
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.ClientUserRelations.Commands.BulkUpdate;
using IdentityServer.Application.Features.ClientUserRelations.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.ClientUserRelations.Handlers.Commands.BulkUpdate;

public class BulkUpdateClientUserRelationCommandHandler : IRequestHandler<BulkUpdateClientUserRelationWrapperCommand, List<BulkUpdateClientUserRelationResponse>>
{
    private readonly IClientUserRelationDal _clientUserRelationDal;
    private readonly ClientUserRelationBusinessRules _clientUserRelationBusinessRules;
    private readonly IMapper _mapper;

    public BulkUpdateClientUserRelationCommandHandler(IMapper mapper, IClientUserRelationDal clientUserRelationDal, ClientUserRelationBusinessRules clientUserRelationBusinessRules)
    {
        _mapper = mapper;
        _clientUserRelationDal = clientUserRelationDal;
        _clientUserRelationBusinessRules = clientUserRelationBusinessRules;
    }

    public async Task<List<BulkUpdateClientUserRelationResponse>> Handle(BulkUpdateClientUserRelationWrapperCommand request, CancellationToken cancellationToken)
    {
        var ids = request.Items.Select(q => q.Id).ToList();
        var datas = await _clientUserRelationDal.GetListAsync(w => ids.Contains(w.Id), cancellationToken : cancellationToken);

        _clientUserRelationBusinessRules.ThrowExceptionIfDataNull(datas);
        
        //İş Kurallarınızı Burada Çağırabilirsiniz.
        foreach(var item in datas.Items)
        {
             var selectedRequest = request.Items.FirstOrDefault(w => w.Id == item.Id);
             if (selectedRequest == null)
             {
                continue;
             }
            _mapper.Map(selectedRequest, item);
        }
        
        await _clientUserRelationDal.UpdateRangeAsync(datas.Items);

        return _mapper.Map<List<BulkUpdateClientUserRelationResponse>>(datas.Items);
    }
}


