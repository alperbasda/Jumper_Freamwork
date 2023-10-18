using IdentityServer.Business.Contracts;
using IdentityServer.Entities.Poco.Client;
using IdentityServer.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UIHelpers;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : ApiControllerBase
    {
        IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpPost("create")]
        [Authorize(Policy = PolicySettings.Admin)]
        public async Task<IActionResult> CreateAsync(CreateClientRequest request)
        {
            return CreateActionResult(await _clientService.Create(request));
        }
    }
}
