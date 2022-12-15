using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DPSample.Services.ServiceInterfaces
{
    public interface ITokenValidatorService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }
}
