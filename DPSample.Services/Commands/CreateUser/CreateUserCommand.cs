using MediatR;

namespace DPSample.Services.Commands.CreateUser
{
    public class CreateUserCommand  : IRequest<CreateUserCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}