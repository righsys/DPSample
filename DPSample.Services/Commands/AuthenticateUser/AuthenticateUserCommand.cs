using MediatR;

namespace DPSample.Services.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand  : IRequest<AuthenticateUserCommandResponse>
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
    }
}