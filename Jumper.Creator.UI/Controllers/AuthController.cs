using Core.WebHelper.ControllerExtensions;
using Jumper.Application.Features.Auth.Commands.Login;
using Jumper.Application.Features.Auth.Commands.Logout;
using Jumper.Creator.UI.ActionFilters;
using Jumper.Creator.UI.AuthHelpers;
using Jumper.Creator.UI.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jumper.Creator.UI.Controllers
{
    public class AuthController : MediatrController
    {
        AuthHelper _authHelper;
        IPublisher _publisher;
        public AuthController(AuthHelper authHelper, IPublisher publisher)
        {
            _authHelper = authHelper;
            _publisher = publisher;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var loginResponse = await  base.Mediator.Send(request);
            _authHelper.Login(loginResponse);
            return RedirectToAction("Index", "Home").Success($"Hoşgeldin {request.UserName}");

        }

        [AuthorizeHandler]
        public async Task<IActionResult> LogOut()
        {
            var token = _authHelper.GetRefreshToken();
            await _publisher.Publish(new LogoutCommand { RefreshToken = token});
            _authHelper.LogOut();
            return RedirectToAction("Login", "Auth").Success("Çıkış Yapıldı");
        }
    }
}
