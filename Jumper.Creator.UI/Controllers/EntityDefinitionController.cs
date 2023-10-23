using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.EntityDefinitions.Commands.Create;
using Jumper.Application.Features.EntityDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityDefinitions.Commands.Update;
using Jumper.Application.Features.EntityDefinitions.Queries.GetById;
using Jumper.Application.Features.EntityDefinitions.Queries.GetListDynamic;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectEntityId;
using Jumper.Domain.Entities;
using Jumper.Domain.MongoEntities;
using Jumper.Application.Features.EntityDefinitions.Queries.GetByLoggedUserId;

namespace Jumper.Creator.UI.Controllers
{
    [Route("entitydefinition")]
    [AuthorizeHandler]
    public class EntityDefinitionController : MediatrController
    {
        public async Task<IActionResult> Index()
        {
            NameValueCollection collection = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value ?? "");
            var data = await base.Mediator.Send(new GetListDynamicEntityDefinitionQuery { DynamicQuery = collection.ToDynamicFilter<EntityDefinition>(), PageRequest = collection.ToPageRequest() });
            return View(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdEntityDefinitionQuery { Id = id });
            return Ok(response);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> ListAsync(NameValueCollection collection)
        {
            var query = new GetListByProjectEntityIdProjectEntityActionQuery
            {
                DynamicQuery = collection.ToDynamicFilter<EntityDefinition>(),
                PageRequest = collection.ToPageRequest()
            };
            var response = await base.Mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("list")]
        public async Task<IActionResult> ListAsync(GetListByProjectEntityIdProjectEntityActionQuery query)
        {
            var response = await base.Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateEntityDefinitionCommand request)
        {
            return Ok(await base.Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateEntityDefinitionCommand request)
        {
            return Ok(await base.Mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            return Ok(await base.Mediator.Send(new DeleteByIdEntityDefinitionCommand { Id = id }));
        }

        [HttpGet("loggeduserdropdown")]
        public async Task<IActionResult> Dropdown()
        {
            var data = await base.Mediator.Send(new GetByLoggedUserIdEntityDefinitionQuery());
            return PartialView("Partials/_Dropdown", data);
        }

    }
}
