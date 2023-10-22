using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jumper.Creator.UI.Controllers.Base
{
    public class MediatrController : Controller
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
