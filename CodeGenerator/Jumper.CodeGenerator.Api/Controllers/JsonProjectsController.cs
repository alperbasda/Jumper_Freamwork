using Core.ApiHelpers;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ArchitectureDefinitions.Queries.GetByIdFromCache;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.Application.Services.Repositories;
using Jumper.CodeGenerator.BuilderBase.ArchitectureCreators;
using Jumper.CodeGenerator.BuilderBase.Starters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Jumper.CodeGenerator.Api.Controllers;

[Route("jsonproject")]
public class JsonProjectsController : ApiControllerBase
{
    private readonly IMediator _mediator;
    private readonly IArchitectureCreator _architectureCreator;
    private readonly ProjectFileCreatorStarter _projectFileCreatorStarter;
    IArchitectureDefinitionDal _architectureDefinitionDal;
    public JsonProjectsController(IArchitectureCreator architectureCreator, IMediator mediator, ProjectFileCreatorStarter projectFileCreatorStarter, IArchitectureDefinitionDal architectureDefinitionDal)
    {
        _architectureCreator = architectureCreator;
        _mediator = mediator;
        _projectFileCreatorStarter = projectFileCreatorStarter;
        _architectureDefinitionDal = architectureDefinitionDal;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(GetWithAllDetailByIdProjectDeclarationQuery request)
    {
        var project = await _mediator.Send(request);

        var architecture = await _mediator.Send(new GetByIdFromCacheArchitectureDefinitionQuery { Id = request.ArchitectureId });

        _architectureCreator.Create(project, architecture);
        await _projectFileCreatorStarter.StartProcess(project, architecture.DllName);

        return Ok(CreateActionResult(Response<MessageResponse>.Success(new MessageResponse { Message = " " }, 200)));
    }

    [HttpPost("download")]
    public async Task<IActionResult> DownloadProject(GetWithAllDetailByIdProjectDeclarationQuery request)
    {
        var project = await _mediator.Send(request);

        return File(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(project)), "application/octet-stream", $"{project.SolutionName}.json");
    }
}
