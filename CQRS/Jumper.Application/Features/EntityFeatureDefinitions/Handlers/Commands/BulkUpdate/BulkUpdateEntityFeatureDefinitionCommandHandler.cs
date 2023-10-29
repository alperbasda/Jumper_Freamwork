
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityFeatureDefinitions.Commands.BulkUpdate;
using Jumper.Application.Features.EntityFeatureDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;
namespace Jumper.Application.Features.EntityFeatureDefinitions.Handlers.Commands.BulkUpdate;

public class BulkUpdateEntityFeatureDefinitionCommandHandler : IRequestHandler<BulkUpdateEntityFeatureDefinitionWrapperCommand, List<BulkUpdateEntityFeatureDefinitionResponse>>
{
    private readonly IEntityFeatureDefinitionDal _entityFeatureDefinitionDal;
    private readonly EntityFeatureDefinitionBusinessRules _entityFeatureDefinitionBusinessRules;
    private readonly IMapper _mapper;

    public BulkUpdateEntityFeatureDefinitionCommandHandler(IMapper mapper, IEntityFeatureDefinitionDal entityFeatureDefinitionDal, EntityFeatureDefinitionBusinessRules entityFeatureDefinitionBusinessRules)
    {
        _mapper = mapper;
        _entityFeatureDefinitionDal = entityFeatureDefinitionDal;
        _entityFeatureDefinitionBusinessRules = entityFeatureDefinitionBusinessRules;
    }

    public async Task<List<BulkUpdateEntityFeatureDefinitionResponse>> Handle(BulkUpdateEntityFeatureDefinitionWrapperCommand request, CancellationToken cancellationToken)
    {
        var ids = request.Items.Select(q => q.Id).ToList();
        var datas = await _entityFeatureDefinitionDal.GetListAsync(w => ids.Contains(w.Id), cancellationToken : cancellationToken);

        await _entityFeatureDefinitionBusinessRules.ThrowExceptionIfDataNull(datas);
        
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
        
        await _entityFeatureDefinitionDal.UpdateRangeAsync(datas.Items);

        return _mapper.Map<List<BulkUpdateEntityFeatureDefinitionResponse>>(datas.Items);
    }
}


