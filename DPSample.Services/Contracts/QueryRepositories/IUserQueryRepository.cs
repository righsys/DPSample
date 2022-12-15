using DPSample.Domain.DbViews;
using DPSample.Domain.Entities;
using DPSample.SharedCore.Interfaces;

namespace DPSample.Services.Contracts.QueryRepositories
{
    public interface IUserQueryRepository : IQueryGenericRepository<User, int>
    {
        Task<bool> ChackUserExistByUsername(string username, CancellationToken cancellationToken);
        Task<UserSummaryDbView> GetUserSummaryByUsername(string username, CancellationToken cancellationToken);
        Task<UserDetailDbView> GetUserDetailByUsername(string username, CancellationToken cancellationToken);
    }
}
