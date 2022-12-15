using MediatR;

namespace DPSample.Services.Queries.ValidateUserLogin
{
    public class ValidateUserLoginQuery : IRequest<ValidateUserLoginQueryResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}