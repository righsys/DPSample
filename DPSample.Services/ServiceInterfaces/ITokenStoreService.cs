using DPSample.Domain.Entities;
using DPSample.SharedServices.Common;

namespace DPSample.Services.ServiceInterfaces
{
    public interface ITokenStoreService
    {      
        Task<bool> IsValidTokenAsync(string accessToken, int userId);
        Task<bool> DeleteExpiredTokensAsync();
        Task<bool> InvalidateUserTokensAsync(int userId);
        Task<JWTTokens> CreateJwtTokens(string username, string password);
    }
}
