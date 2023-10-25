using Jumper.Application.Features.PropertyInputTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Creator.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jumper.Creator.UI.Controllers;

public class PropertyInputTypeDeclarationController : MediatrController
{
    public async Task<IActionResult> Dropdown(SelectBoxModel model)
    {
        ViewData["SelectBoxModel"] = model;
        var data = await base.Mediator.Send(new GetAllFromCachePropertyInputTypeDeclarationQuery());
        return PartialView("Partials/_Dropdown",data);
    }
}
