
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 24.10.2023 10:52
//---------------------------------------------------------------------------------------

using IdentityServer.Application.Features.ApiResources.Commands.Create;
using IdentityServer.Application.Features.ApiResources.Commands.DeleteById;
using IdentityServer.Application.Features.ApiResources.Commands.Update;
using IdentityServer.Application.Features.ApiResources.Queries.GetById;
using IdentityServer.Application.Features.ApiResources.Queries.ListDynamic;
using IdentityServer.UI.Api.ActionFilters;
using IdentityServer.UI.Api.Controllers.Base;
using Core.Persistence.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;
using Core.WebHelper.NameValueCollectionHelpers;
using IdentityServer.Domain.Entities;

namespace IdentityServer.UI.Api.Controllers
{
    [Route("ApiResources")]
    public class ApiResourcesController : MediatrController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdApiResourceQuery { Id = id });
            return Ok(Response<GetByIdApiResourceResponse>.Success(response,200));
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> ListAsync(NameValueCollection collection)
        {
            var query = new ListDynamicApiResourceQuery
            {
                DynamicQuery = collection.ToDynamicFilter<ApiResource>(),
                PageRequest = collection.ToPageRequest()
            };
            var response = await base.Mediator.Send(query);

            return Ok(Response<ListModel<ListDynamicApiResourceResponse>>.Success(response,200));
        }

        [HttpPost("list")]
        public async Task<IActionResult> ListAsync(ListDynamicApiResourceQuery query)
        {
            var response = await base.Mediator.Send(query);
            return Ok(Response<ListModel<ListDynamicApiResourceResponse>>.Success(response,200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateApiResourceCommand request)
        {
            return Ok(Response<CreateApiResourceResponse>.Success(await base.Mediator.Send(request), 200));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateApiResourceCommand request)
        {
            return Ok(Response<UpdateApiResourceResponse>.Success(await base.Mediator.Send(request), 200));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            return Ok(Response<DeleteByIdApiResourceResponse>.Success(await base.Mediator.Send(new DeleteByIdApiResourceCommand { Id = id }), 200));
        }

    }
}


