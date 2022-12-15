using DPSample.Domain.Entities;
using DPSample.Infrastructure.DbContexts;
using DPSample.Infrastructure.RepositoryBase;
using DPSample.Services.Contracts.QueryRepositories;

namespace DPSample.Infrastructure.Repositories.QueryRepositories
{
    public class UserRoleQueryRepository : QueryRepositoryBase<UserRole, int>, IUserRoleQueryRepository
    {
        private readonly QueryDbContext _queryDbContext;
        public UserRoleQueryRepository(QueryDbContext queryDbContext) : base(queryDbContext) => _queryDbContext = queryDbContext;
    }
}