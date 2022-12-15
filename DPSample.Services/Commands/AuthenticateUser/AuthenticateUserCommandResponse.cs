using DPSample.SharedServices.Common;

namespace DPSample.Services.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandResponse : CommandResponseBase
    {
        public JWTTokens Token { get; set; }
    }
}