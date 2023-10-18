using AutoMapper;
using Core.ApiHelpers.JwtHelper.Models;
using Core.WebHelper.ControllerExtensions;
using Core.WebHelper.NameValueCollectionHelpers;
using Jumper.Application.Features.ProjectDeclarations.Commands.Create;
using Jumper.Application.Features.ProjectDeclarations.Commands.DeleteById;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateCacheSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateInfo;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateNoSqlDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRabbitMqSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRelationalDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateSerilogSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetById;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForCacheSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForLogSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForNoSqlDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRabbitMqSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRelationalDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByLoggedUserId;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetListDynamic;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.Controllers.Base;
using Jumper.Creator.UI.Models;
using Jumper.Creator.UI.Models.Enum;
using Jumper.Domain.MongoEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Web;

namespace Jumper.Creator.UI.Controllers
{
    [Route("project")]
    [AuthorizeHandler]
    public class ProjectController : MediatrController
    {
        TokenParameters _tokenParameters;
        IMapper _mapper;

        public ProjectController(TokenParameters tokenParameters, IMapper mapper)
        {
            _tokenParameters = tokenParameters;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            NameValueCollection collection = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.Value ?? "");
            var data = await base.Mediator.Send(new GetListDynamicProjectDeclarationQuery { DynamicQuery = collection.ToDynamicFilter<ProjectDeclaration>(), PageRequest = collection.ToPageRequest() });
            return View(data);
        }

        [HttpGet("projectinfopartial")]
        public async Task<IActionResult> ProjectInfoPartial(Guid id, ProjectInfoMenuSelection selected)
        {
            ViewData["SelectedMenu"] = selected;
            var response = await base.Mediator.Send(new GetByIdProjectDeclarationQuery { Id = id });
            return PartialView("Partials/_ProjectInfo", response);
        }

        [HttpGet("updateinfosticky")]
        public async Task<IActionResult> UpdateInfoSticky(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdProjectDeclarationQuery { Id = id });
            return PartialView("Partials/_ProjectInfoSticky", response);
        }



        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProjectDeclarationCommandWithOutCache request)
        {
            CreateProjectDeclarationCommand reelRequest = new CreateProjectDeclarationCommand(_tokenParameters);
            _mapper.Map(request, reelRequest);
            var createResponse = await base.Mediator.Send(reelRequest);
            return RedirectToAction("UpdateInfo", "Project", new { Id = createResponse.Id }).Success($"{createResponse.Name} projesi kayıt edildi.");
        }

        [HttpGet("updateinfo")]
        public async Task<IActionResult> UpdateInfo(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdProjectDeclarationQuery { Id = id });

            return View(response);
        }

    
        [HttpGet("updaterabbitmqsettings")]
        public async Task<IActionResult> UpdateRabbitMqSettings(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdForRabbitMqSettingsProjectDeclarationQuery { Id = id });
            return View(response);
        }

        [HttpGet("updateserilogsettings")]
        public async Task<IActionResult> UpdateSerilogSettings(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdForLogSettingsProjectDeclarationQuery { Id = id });
            return View(response);
        }

        [HttpGet("updatecachesettings")]
        public async Task<IActionResult> UpdateCacheSettings(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdForCacheSettingsProjectDeclarationQuery { Id = id });
            return View(response);
        }

        [HttpGet("updatenosqldatabasesettings")]
        public async Task<IActionResult> UpdateNoSqlDatabaseSettings(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdForNoSqlDatabaseSettingsProjectDeclarationQuery { Id = id });
            return View(response);
        }


        [HttpGet("updaterelationaldatabasesettings")]
        public async Task<IActionResult> UpdateRelationalDatabaseSettings(Guid id)
        {
            var response = await base.Mediator.Send(new GetByIdForRelationalDatabaseSettingsProjectDeclarationQuery { Id = id });
            return View(response);
        }

        [HttpPost("updateinfo")]
        public async Task<IActionResult> UpdateInfo(UpdateInfoProjectDeclarationCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("UpdateInfo", "Project", new { Id = updateResponse.Id }).Success($"{updateResponse.Name} projesi güncellendi.");
        }

        [HttpPost("updatecachesettings")]
        public async Task<IActionResult> UpdateCacheSettings(UpdateCacheSettingsProjectDeclarationCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("UpdateCacheSettings", "Project", new { Id = updateResponse.Id }).Success($"{updateResponse.Name} projesi cache ayarları güncellendi.");
        }

        [HttpPost("updaterelationaldatabasesettings")]
        public async Task<IActionResult> UpdateRelationalDatabaseSettings(UpdateRelationalDatabaseSettingsProjectDeclarationCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("UpdateRelationalDatabaseSettings", "Project", new { Id = updateResponse.Id }).Success($"Projenin relational database ayarları güncellendi.");
        }

        [HttpPost("updatenosqldatabasesettings")]
        public async Task<IActionResult> UpdateNoSqlDatabaseSettings(UpdateNoSqlDatabaseSettingsProjectDeclarationCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("UpdateNoSqlDatabaseSettings", "Project", new { Id = updateResponse.Id }).Success($"Projenin nosql database ayarları güncellendi.");
        }

        [HttpPost("updateserilogsettings")]
        public async Task<IActionResult> UpdateSerilogSettings(UpdateSerilogSettingsProjectDeclarationCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("UpdateSerilogSettings", "Project", new { Id = updateResponse.Id }).Success($"{updateResponse.Name} projesi serilog ayarları güncellendi.");
        }

        [HttpPost("updaterabbitmqsettings")]
        public async Task<IActionResult> UpdateRabbitMqSettings(UpdateRabbitMqSettingsProjectDeclarationCommand request)
        {
            var updateResponse = await base.Mediator.Send(request);
            return RedirectToAction("UpdateRabbitMqSettings", "Project", new { Id = updateResponse.Id }).Success($"{updateResponse.Name} projesi rabbitmq ayarları güncellendi.");
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _ = await base.Mediator.Send(new DeleteByIdProjectDeclarationCommand(_tokenParameters) { Id = id });
            return Json("Proje Silindi.");
        }

		[HttpGet("directdelete")]
		public async Task<IActionResult> DeleteDirect(Guid id)
		{
			_ = await base.Mediator.Send(new DeleteByIdProjectDeclarationCommand(_tokenParameters) { Id = id });
            return RedirectToAction("Index", "Home");
		}

		[HttpGet("menupartial")]
        public async Task<IActionResult> Menu()
        {
            var menuItems = await base.Mediator.Send(new GetByLoggedUserIdProjectDeclarationQuery(_tokenParameters));
            return PartialView("Partials/_MenuItems", menuItems);
        }

        [HttpGet("projectsdropdownpartial")]
        public async Task<IActionResult> Dropdown(SelectBoxModel model)
        {
            ViewData["SelectBoxModel"] = model;
            var dropdownItems = await base.Mediator.Send(new GetByLoggedUserIdProjectDeclarationQuery(_tokenParameters));
            return PartialView("Partials/_Dropdown", dropdownItems.Items);
        }

    }
}
