using Microsoft.AspNetCore.Mvc;
using System.Resources;
using System.Threading.Tasks;
using TopTests.API.Resources;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Tokens;

namespace CarRental.API.Controllers
{
    [Route("api/refresh")]
    [ApiController]
    public class TokensController : Controller
    {
        public ITokenService tokenService;
        public ResourceManager resourcesManager;
        public TokensController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
            resourcesManager = new ResourceManager("TopTests.API.Resources.ResourceFile", typeof(ResourceFile).Assembly);
        }
        /// <summary>
        /// Refresh token with correct refresh token 
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns>return new Access token and Refresh set old
        /// refresh token on false
        /// else return 401(UnAuthorized)</returns>
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync(TokenDto refreshToken)
        {
            var refresh = await tokenService.CheckAccessRefreshTokenAsync(refreshToken.RefreshToken);
            if (!refresh.CheckRefreshToken)
            {
                return Unauthorized(resourcesManager.GetString("BadRefreshToken"));
            }
            else
            {
                var newToken = await tokenService.GenerateRefreshTokenAsync(refresh);
                await tokenService.SaveRefreshTokenAsync(refresh.UserId, newToken.RefreshToken, true);
                return Ok(newToken);
            }
        }
    }
}