using DPSample.Api.DTOs;
using DPSample.Services.Commands.CreateUser;
using DPSample.Services.Queries.GetAllUsers;
using DPSample.SharedServices.Interfaces;
using DPSample.Utilities.DateTimeHelper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DPSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserAdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDateTimeHelper _dateTimeHelper;
        public UserAdminController(IMediator mediator, IDateTimeHelper dateTimeHelper)
        {
            _mediator = mediator;
            _dateTimeHelper = dateTimeHelper;
        }       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsersDetail()
        {
            GetAllUsersDetailQuery query = new GetAllUsersDetailQuery() { };
            GetAllUsersDetailQueryResponse response = await _mediator.Send(query);
            if (response.Success)
                return Ok(response.Users);
            return StatusCode(StatusCodes.Status500InternalServerError, response.CustomErrorMessage);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreateDto createDto) 
        {
            CreateUserCommand command = new CreateUserCommand() 
            {
                FirstName=createDto.FirstName,
                LastName=createDto.LastName,
                Username=createDto.Username,
                Email=createDto.Email,
                IsActive=createDto.IsActive,
                NationalCode=createDto.NationalCode,
                Password=createDto.Password
            };
            CreateUserCommandResponse response= await _mediator.Send(command); 
            if(response.Success)
                return Ok("ثبت اطلاعات موفقیت آمیز بود");
            return StatusCode(StatusCodes.Status500InternalServerError, response.CustomErrorMessage);
        }
    }
}