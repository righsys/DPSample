using DPSample.Services.Commands.AuthenticateUser;
using DPSample.Services.Commands.LogoutUser;
using DPSample.Services.ServiceInterfaces;
using DPSample.SharedServices.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DPSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenStoreService _tokenStoreService;

        public AuthenticationController( ITokenStoreService tokenStoreService)
        {
            _tokenStoreService = tokenStoreService;
        }
        //
        // Log in to the system
        //
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(string username, string password)
        {
            JWTTokens token = await _tokenStoreService.CreateJwtTokens(username, password);                        
            if (token is not null)
                return Ok(new { token.Token, token.RefreshToken });
            return Unauthorized("ابتدا باید وارد شوید");
        }
        //
        // Log out from the system
        //
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> Logout()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;

            if (!string.IsNullOrWhiteSpace(userIdValue) && int.TryParse(userIdValue, out int userId))
            {
                bool success = await _tokenStoreService.InvalidateUserTokensAsync(userId);
                if (success)
                    return Ok("You logged out.");
                return StatusCode(StatusCodes.Status500InternalServerError, "خطا در پردازش اطلاعات ورودی");
            }
            return BadRequest("Bad Request");
        }
    }
}
