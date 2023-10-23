using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.ProjectEntities.Commands.Create;
using Jumper.Application.Features.ProjectEntities.Commands.CreateFromDefinition;
using Jumper.Application.Features.ProjectEntities.Commands.Delete;
using Jumper.Application.Features.ProjectEntities.Commands.Update;
using Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Creator.UI.Models;
using Jumper.Creator.UI.Models.Enum;
using Jumper.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;

namespace Jumper.Creator.UI.Controllers;

[Route("projectentity")]
[AuthorizeHandler]
public class ProjectEntityController : MediatrController
{
    public async Task<IActionResult> Index(Guid projectId)
    {
        ViewData["projectId"] = projectId;
        NameValueCollection collection = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value ?? "");
        var data = await base.Mediator.Send(new GetListByProjectIdProjectEntityQuery { ProjectDeclarationId = projectId, DynamicQuery = collection.ToDynamicFilter<ProjectEntity>(), PageRequest = collection.ToPageRequest() });
        return View(data);
    }

    [HttpGet("createpartial")]
    public async Task<IActionResult> CreatePartial(CreateProjectEntityCommand command)
    {
        return PartialView("Partials/_Create", command);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProjectEntityCommand command)
    {
        _ = await base.Mediator.Send(command);
        return RedirectToAction("Index", "ProjectEntity", new { projectId = command.ProjectDeclarationId });
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateProjectEntityCommand command)
    {
        _ = await base.Mediator.Send(command);
        return RedirectToAction("Index", "ProjectEntity", new { projectId = command.ProjectDeclarationId });
    }

    [HttpPost("createfromdefinition")]
    public async Task<IActionResult> CreateFromDefinition(CreateFromDefinitionProjectEntityCommand command)
    {
        _ = await base.Mediator.Send(command);
        return RedirectToAction("Index", "ProjectEntity", new { projectId = command.ProjectDeclarationId });
    }

    [HttpGet("delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        _ = await base.Mediator.Send(new DeleteProjectEntityCommand { Id = id });
        return Json("Nesne Silindi.");
    }


    [HttpGet("propertycreationdropdown")]
    public async Task<IActionResult> DropdownForProperyCreation(GetListByProjectIdProjectEntityQuery command)
    {
        ViewData["selected"] = command;
        var data = await base.Mediator.Send(command);
        return PartialView("Partials/_DropdownForProperyCreation", data);
    }

    [HttpGet("projectsdropdownpartial")]
    public async Task<IActionResult> Dropdown(SelectBoxModel model, Guid projectId)
    {
        ViewData["SelectBoxModel"] = model;
        var request =  new GetListByProjectIdProjectEntityQuery { ProjectDeclarationId = projectId };
        request.PageRequest = new Core.Persistence.Requests.PageRequest { PageIndex = 0, PageSize = int.MaxValue };
        var dropdownItems = await base.Mediator.Send(request);
        return PartialView("Partials/_Dropdown", dropdownItems.Items);
    }

}
