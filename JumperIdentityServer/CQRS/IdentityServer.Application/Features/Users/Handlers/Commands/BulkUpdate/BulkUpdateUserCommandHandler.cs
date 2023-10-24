
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.Users.Commands.BulkUpdate;
using IdentityServer.Application.Features.Users.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.Users.Handlers.Commands.BulkUpdate;

public class BulkUpdateUserCommandHandler : IRequestHandler<BulkUpdateUserWrapperCommand, List<BulkUpdateUserResponse>>
{
    private readonly IUserDal _userDal;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public BulkUpdateUserCommandHandler(IMapper mapper, IUserDal userDal, UserBusinessRules userBusinessRules)
    {
        _mapper = mapper;
        _userDal = userDal;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<List<BulkUpdateUserResponse>> Handle(BulkUpdateUserWrapperCommand request, CancellationToken cancellationToken)
    {
        var ids = request.Items.Select(q => q.Id).ToList();
        var datas = await _userDal.GetListAsync(w => ids.Contains(w.Id), cancellationToken : cancellationToken);

        _userBusinessRules.ThrowExceptionIfDataNull(datas);
        
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
        
        await _userDal.UpdateRangeAsync(datas.Items);

        return _mapper.Map<List<BulkUpdateUserResponse>>(datas.Items);
    }
}


