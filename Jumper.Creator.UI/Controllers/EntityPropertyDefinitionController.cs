using Core.WebHelper.ControllerExtensions;
using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.Create;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.Update;
using Jumper.Application.Features.EntityPropertyDefinitions.Queries.GetListByEntityDefinitionId;
using Jumper.Application.Features.PropertyTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Web;

namespace Jumper.Creator.UI.Controllers
{
    [Route("propertydefinition")]
    [AuthorizeHandler]
    public class EntityPropertyDefinitionController : MediatrController
    {
        [HttpGet("listforentitydefinitionpartial")]
        public async Task<IActionResult> ListForEntityDefinition(Guid entityDefinitionId)
        {
            NameValueCollection collection = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value ?? "");
            var data = await base.Mediator.Send(new GetListByEntityDefinitionIdEntityPropertyDefinitionQuery { DynamicQuery = collection.ToDynamicFilter<EntityPropertyDefinition>(), PageRequest = collection.ToPageRequest(), EntityDefinitionId = entityDefinitionId });

            return PartialView("Partials/_List", data);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create(Guid entityDefinitionId)
        {
            return PartialView("Partials/_Create",new CreateEntityPropertyDefinitionCommand { EntityDefinitionId = entityDefinitionId});
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateEntityPropertyDefinitionCommand request)
        {
            _ = await base.Mediator.Send(request);
            return RedirectToAction("update","EntityDefinition", new {id=request.EntityDefinitionId});
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateEntityPropertyDefinitionCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("Update", "EntityPropertyDefinition", new { id = updateResponse.Id }).Success($"{updateResponse.Name} nesne özelliği güncellendi.");
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _ = await base.Mediator.Send(new DeleteByIdEntityPropertyDefinitionCommand { Id = id });
            return Json("Nesne Silindi.");
        }
    }
}
