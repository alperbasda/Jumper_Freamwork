using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.ProjectEntityActions.Commands.Create;
using Jumper.Application.Features.ProjectEntityActions.Commands.Delete;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectEntityId;
using Jumper.Application.Features.ProjectEntityProperties.Queries.GetListByProjectEntityId;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;

[Route("projectentityaction")]
[AuthorizeHandler]
public class ProjectEntityActionController : MediatrController
{
    [HttpGet("index")]
    public async Task<IActionResult> Index(GetListByProjectEntityIdProjectEntityActionQuery command, Guid projectId)
    {
        ViewData["ProjectEntityId"] = command.ProjectEntityId;
        ViewData["ProjectId"] = projectId;

        NameValueCollection collection = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value ?? "");
        command.DynamicQuery = collection.ToDynamicFilter<ProjectEntityAction>();
        command.PageRequest = collection.ToPageRequest();
        var data = await base.Mediator.Send(command);
        return View(data);
    }

    [HttpGet("create")]
    public async Task<IActionResult> CreatePartial(CreateProjectEntityActionCommand command)
    {
        ViewData["ProjectEntityProperties"] = (await Mediator.Send(new GetListByProjectEntityIdProjectEntityPropertyQuery { ProjectEntityId = command.ProjectEntityId })).Items;

        return PartialView("Partials/_Create", command);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProjectEntityActionCommand command)
    {
        _ = await base.Mediator.Send(command);
        return RedirectToAction("Index", "ProjectEntityAction", new { command.ProjectEntityId, projectId = Request.Form["projectId"] });
    }

    [HttpGet("delete")]
    public async Task<IActionResult> Delete(DeleteProjectEntityActionCommand command)
    {
        _ = await base.Mediator.Send(command);
        return Json("Nesne Silindi.");
    }
}