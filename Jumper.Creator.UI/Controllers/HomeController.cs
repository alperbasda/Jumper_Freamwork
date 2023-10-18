using Core.ApiHelpers.JwtHelper.Models;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByLoggedUserId;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Jumper.Creator.UI.Controllers;

[AuthorizeHandler]
public class HomeController : MediatrController
{
    TokenParameters _tokenParameters;
    public HomeController(TokenParameters tokenParameters)
    {
        _tokenParameters = tokenParameters;
    }

    public async Task<IActionResult> Index()
    {
        return View(await base.Mediator.Send(new GetByLoggedUserIdProjectDeclarationQuery(_tokenParameters)));
    }

    [Route("home/examples")]
    public IActionResult JsonExamples()
    {
        return View();
    }

}