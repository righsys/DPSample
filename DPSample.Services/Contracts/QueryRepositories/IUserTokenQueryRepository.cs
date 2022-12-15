using DPSample.Domain.Entities;
using DPSample.SharedCore.Interfaces;

namespace DPSample.Services.Contracts.QueryRepositories
{
    public interface IUserTokenQueryRepository:IQueryGenericRepository<UserToken, int>
    {
        Task<List<UserToken>> GetTokens(int userId);
        Task<UserToken> GetToken(string accessToken, int userId);
    }
}
