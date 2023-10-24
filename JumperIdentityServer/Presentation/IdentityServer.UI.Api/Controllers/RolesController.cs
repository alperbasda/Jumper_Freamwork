
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using IdentityServer.Application.Features.Roles.Commands.Create;
using IdentityServer.Application.Features.Roles.Commands.DeleteById;
using IdentityServer.Application.Features.Roles.Commands.Update;
using IdentityServer.Application.Features.Roles.Queries.GetById;
using IdentityServer.Application.Features.Roles.Queries.ListDynamic;
using IdentityServer.UI.Api.ActionFilters;
using IdentityServer.UI.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;
using Core.WebHelper.NameValueCollectionHelpers;
using IdentityServer.Domain.Entities;

namespace IdentityServer.UI.Api.Controllers
{
    [Route("Roles")]
    public class RolesController : MediatrController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdRoleQuery { Id = id });
            return Ok(response);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> ListAsync(NameValueCollection collection)
        {
            var query = new ListDynamicRoleQuery
            {
                DynamicQuery = collection.ToDynamicFilter<Role>(),
                PageRequest = collection.ToPageRequest()
            };
            var response = await base.Mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("list")]
        public async Task<IActionResult> ListAsync(ListDynamicRoleQuery query)
        {
            var response = await base.Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateRoleCommand request)
        {
            return Ok(await base.Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateRoleCommand request)
        {
            return Ok(await base.Mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            return Ok(await base.Mediator.Send(new DeleteByIdRoleCommand { Id = id }));
        }

    }
}


