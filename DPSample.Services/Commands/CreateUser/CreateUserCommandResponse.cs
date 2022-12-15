using DPSample.Domain.Enums;
using DPSample.SharedServices.Common;

namespace DPSample.Services.Commands.CreateUser
{
    public class CreateUserCommandResponse  :CommandResponseBase
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public UserRegisterResponseStatus RegisterResponseStatus { get; set; }
    }
}