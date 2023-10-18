using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.DeleteById;
using Jumper.Application.Features.ProjectEntityDependencies.Queries.GetListProjectEntityId;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;

namespace Jumper.Creator.UI.Controllers;

[Route("projectentitydependency")]
[AuthorizeHandler]
public class ProjectEntityDependencyController : MediatrController
{
    [HttpGet("index")]
    public async Task<IActionResult> Index(GetListProjectEntityIdProjectEntityDependencyQuery command, Guid projectId)
    {
        ViewData["ProjectId"] = projectId;
        command.ProjectDeclarationId = projectId;
        NameValueCollection collection = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value ?? "");
        command.DynamicQuery = collection.ToDynamicFilter<ProjectEntityDependency>();
        command.PageRequest = collection.ToPageRequest();
        
        var data = await base.Mediator.Send(command);
        return View(data);
    }

    [HttpGet("create")]
    public async Task<IActionResult> CreatePartial(CreateProjectEntityDependencyCommand command)
    {
        return PartialView("Partials/_Create", command);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProjectEntityDependencyCommand command)
    {
        _ = await base.Mediator.Send(command);
        return RedirectToAction("Index", "ProjectEntityDependency", new { projectId = Request.Form["ProjectDeclarationId"] });
    }

    [HttpGet("delete")]
    public async Task<IActionResult> Delete(DeleteByIdProjectEntityDependencyCommand command)
    {
        _ = await base.Mediator.Send(command);
        return Json("Nesne Silindi.");
    }
}
