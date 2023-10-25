using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.ProjectEntityProperties.Commands.Create;
using Jumper.Application.Features.ProjectEntityProperties.Commands.Delete;
using Jumper.Application.Features.ProjectEntityProperties.Queries.GetListByProjectEntityId;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;

namespace Jumper.Creator.UI.Controllers;

[Route("projectentityproperty")]
[AuthorizeHandler]
public class ProjectEntityPropertyController : MediatrController
{
    [HttpGet("index")]
    public async Task<IActionResult> Index(GetListByProjectEntityIdProjectEntityPropertyQuery command,Guid projectId)
    {
        ViewData["ProjectEntityId"] = command.ProjectEntityId;
        ViewData["ProjectId"] = projectId;

        NameValueCollection collection = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value ?? "");
        command.DynamicQuery = collection.ToDynamicFilter<ProjectEntityProperty>();
        command.PageRequest = collection.ToPageRequest();
        var data = await base.Mediator.Send(command);
        return View(data);
    }

    [HttpGet("create")]
    public async Task<IActionResult> CreatePartial(CreateProjectEntityPropertyCommand command)
    {
        return PartialView("Partials/_Create", command);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProjectEntityPropertyCommand command)
    {
        _ = await base.Mediator.Send(command);
        return RedirectToAction("Index", "ProjectEntityProperty", new {command.ProjectEntityId,projectId= Request.Form["projectId"] });
    }

    [HttpGet("delete")]
    public async Task<IActionResult> Delete(DeleteProjectEntityPropertyCommand command)
    {
        _ = await base.Mediator.Send(command);
        return Json("Nesne Silindi.");
    }

}
