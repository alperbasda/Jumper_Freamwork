
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.ApiResources.Commands.Update;
using IdentityServer.Application.Features.ApiResources.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.ApiResources.Handlers.Commands.Update;

public class UpdateApiResourceCommandHandler : IRequestHandler<UpdateApiResourceCommand, UpdateApiResourceResponse>
{
    private readonly IApiResourceDal _apiResourceDal;
    private readonly ApiResourceBusinessRules _apiResourceBusinessRules;
    private readonly IMapper _mapper;

    public UpdateApiResourceCommandHandler(IMapper mapper, IApiResourceDal apiResourceDal, ApiResourceBusinessRules apiResourceBusinessRules)
    {
        _mapper = mapper;
        _apiResourceDal = apiResourceDal;
        _apiResourceBusinessRules = apiResourceBusinessRules;
    }

    public async Task<UpdateApiResourceResponse> Handle(UpdateApiResourceCommand request, CancellationToken cancellationToken)
    {
        var data = await _apiResourceDal.GetAsync(w => w.Id == request.Id);

        _apiResourceBusinessRules.ThrowExceptionIfDataNull(data);
        
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        _mapper.Map(request, data);
        await _apiResourceDal.UpdateAsync(data);

        return _mapper.Map<UpdateApiResourceResponse>(data);
    }
}


