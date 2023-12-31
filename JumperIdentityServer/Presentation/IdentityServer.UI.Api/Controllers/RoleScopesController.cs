
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 24.10.2023 10:52
//---------------------------------------------------------------------------------------

using IdentityServer.Application.Features.RoleScopes.Commands.Create;
using IdentityServer.Application.Features.RoleScopes.Commands.DeleteById;
using IdentityServer.Application.Features.RoleScopes.Commands.Update;
using IdentityServer.Application.Features.RoleScopes.Queries.GetById;
using IdentityServer.Application.Features.RoleScopes.Queries.ListDynamic;
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
    [Route("RoleScopes")]
    public class RoleScopesController : MediatrController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdRoleScopeQuery { Id = id });
            return Ok(Response<GetByIdRoleScopeResponse>.Success(response,200));
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> ListAsync(NameValueCollection collection)
        {
            var query = new ListDynamicRoleScopeQuery
            {
                DynamicQuery = collection.ToDynamicFilter<RoleScope>(),
                PageRequest = collection.ToPageRequest()
            };
            var response = await base.Mediator.Send(query);

            return Ok(Response<ListModel<ListDynamicRoleScopeResponse>>.Success(response,200));
        }

        [HttpPost("list")]
        public async Task<IActionResult> ListAsync(ListDynamicRoleScopeQuery query)
        {
            var response = await base.Mediator.Send(query);
            return Ok(Response<ListModel<ListDynamicRoleScopeResponse>>.Success(response,200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateRoleScopeCommand request)
        {
            return Ok(Response<CreateRoleScopeResponse>.Success(await base.Mediator.Send(request), 200));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateRoleScopeCommand request)
        {
            return Ok(Response<UpdateRoleScopeResponse>.Success(await base.Mediator.Send(request), 200));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            return Ok(Response<DeleteByIdRoleScopeResponse>.Success(await base.Mediator.Send(new DeleteByIdRoleScopeCommand { Id = id }), 200));
        }

    }
}


