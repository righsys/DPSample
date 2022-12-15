using DPSample.Domain.Entities;
using DPSample.SharedCore.Interfaces;

namespace DPSample.Services.Contracts.QueryRepositories
{
    public interface IUserRoleQueryRepository : IQueryGenericRepository<UserRole, int>
    {
    }
}
