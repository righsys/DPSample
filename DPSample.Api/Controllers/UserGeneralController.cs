using DPSample.Services.Queries.GetUserInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace DPSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "General")]
    public class UserGeneralController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserGeneralController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCurrent")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                var usernameValue = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
                GetUserInfoQuery query = new GetUserInfoQuery() { Username = usernameValue };
                GetUserInfoQueryResponse response = await _mediator.Send(query);
                if (response.Success)
                    return Ok(response.UserSummary);
                return StatusCode(StatusCodes.Status500InternalServerError, "خطا در پردازش اطلاعات ورودی");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "خطا در پردازش اطلاعات");
            }
            

        }
    }
}
