using Core.WebHelper.ControllerExtensions;
using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.EntityDefinitions.Commands.Create;
using Jumper.Application.Features.EntityDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityDefinitions.Commands.Update;
using Jumper.Application.Features.EntityDefinitions.Queries.GetById;
using Jumper.Application.Features.EntityDefinitions.Queries.GetByLoggedUserId;
using Jumper.Application.Features.EntityDefinitions.Queries.GetListDynamic;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Domain.Entities;
using Jumper.Domain.MongoEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;

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

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateEntityDefinitionCommand request)
        {
            var createResponse = await base.Mediator.Send(request);
            return RedirectToAction("Update", "EntityDefinition", new { id = createResponse.Id }).Success($"{createResponse.Name} nesnesi kayıt edildi.");
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdEntityDefinitionQuery { Id = id });
            return View(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateEntityDefinitionCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("Update", "EntityDefinition", new { id = updateResponse.Id }).Success($"{updateResponse.Name} nesnesi güncellendi.");
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _ = await base.Mediator.Send(new DeleteByIdEntityDefinitionCommand { Id = id });
            return Json("Nesne Silindi.");
        }

        [HttpGet("loggeduserdropdown")]
        public async Task<IActionResult> Dropdown()
        {
            var data  = await base.Mediator.Send(new GetByLoggedUserIdEntityDefinitionQuery());
            return PartialView("Partials/_Dropdown", data);
        }
    }
}
