using ExpressionBuilder.Models;
using IdentityServer.Business.Contracts;
using IdentityServer.Entities.Poco.User;
using IdentityServer.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UIHelpers;
using IdentityServer.Entities.Db;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    public class IdentityUsersController : ApiControllerBase
    {
        private readonly IIdentityUserService _identityUserService;
        
        public IdentityUsersController(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        #region Get

        [HttpGet]
        [Authorize(Policy = PolicySettings.Admin)]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Verilen Idye sahip veriyi getirir. Bulamassa 404 döner. (Policy : SuperUser)")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return CreateActionResult(await _identityUserService.GetAsync(id));
        }

        [HttpGet("byClient/{clientId}/{page}")]
        [Authorize(Policy = PolicySettings.Admin)]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Verilen clienttaki kullanıcıları döner. (Policy : SuperUser)")]
        public async Task<IActionResult> GetByClientAsync(string clientId,int page)
        {
            var fm = FilterModel.Get(nameof(IdentityUser.ClientId), FilterOperator.Equals, clientId);
            fm.Page= page;
            return CreateActionResult(await _identityUserService.GetAsync(fm));
        }

        #endregion

        #region Create

        [HttpPost("create")]
        [Authorize(Policy = PolicySettings.Manager)]
        public async Task<IActionResult> CreateAsync(CreateIdentityUserRequest request)
        {
            return CreateJsonResult(await _identityUserService.Create(request));
        }

        #endregion


        #region Update
        [HttpPost("update")]
        [Authorize(Policy = PolicySettings.Manager)]
        public async Task<IActionResult> UpdateAsync(UpdateIdentityUserRequest request)
        {
            return CreateJsonResult(await _identityUserService.Update(request));
        }

        #endregion
    }
}
