using MediatR;

namespace DPSample.Services.Commands.LogoutUser
{
    public class LogoutUserCommand : IRequest<LogoutUserCommandResponse>
    {
        public int UserId { get; set; }

    }
}