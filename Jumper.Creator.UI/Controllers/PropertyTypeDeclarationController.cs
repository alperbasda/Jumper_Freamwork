using Jumper.Application.Features.PropertyTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Creator.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jumper.Creator.UI.Controllers;

public class PropertyTypeDeclarationController : MediatrController
{

    public async Task<IActionResult> Dropdown(SelectBoxModel model)
    {
        ViewData["SelectBoxModel"] = model;
        var data = await base.Mediator.Send(new GetAllFromCachePropertyTypeDeclarationQuery());
        return PartialView("Partials/_Dropdown",data);
    }
}
