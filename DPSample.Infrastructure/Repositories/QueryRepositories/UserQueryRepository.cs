using Dapper;
using DPSample.Domain.DbViews;
using DPSample.Domain.Entities;
using DPSample.Infrastructure.DbContexts;
using DPSample.Infrastructure.RepositoryBase;
using DPSample.Services.Contracts.QueryRepositories;

namespace DPSample.Infrastructure.Repositories.QueryRepositories
{
    public class UserQueryRepository : QueryRepositoryBase<User, int>, IUserQueryRepository
    {
        private readonly QueryDbContext _queryDbContext;
        public UserQueryRepository(QueryDbContext queryDbContext) : base(queryDbContext) => _queryDbContext = queryDbContext;

        public async Task<bool> ChackUserExistByUsername(string username, CancellationToken cancellationToken) 
        {
            string query = $"SELECT UserId FROM [User] WHERE Username = @Username";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryAsync<User>(query, new { Username = username }), cancellationToken);
                connection.Close();
                return result.Any();
            }
        }

        public async Task<UserDetailDbView> GetUserDetailByUsername(string username, CancellationToken cancellationToken)
        {
            var properties = typeof(UserDetailDbView).GetProperties().ToList();
            List<string> cols = new List<string>();
            foreach (var property in properties)
            {
                cols.Add($"[{property.Name}]");
            }
            string query = $"SELECT {string.Join(",", cols)} FROM [User] Inner Join UserRole on [User].UserRoleId = UserRole.UserRoleId WHERE Username = @Username";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryFirstOrDefaultAsync<UserDetailDbView>(query, new { Username = username }), cancellationToken);
                connection.Close();
                return result;
            }
        }

        public async Task<UserSummaryDbView> GetUserSummaryByUsername(string username, CancellationToken cancellationToken) 
        {
            var properties = typeof(UserSummaryDbView).GetProperties().ToList();
            List<string> cols = new List<string>();
            foreach (var property in properties)
            {
                cols.Add($"[{property.Name}]");
            }
            string query = $"SELECT {string.Join(",", cols)} FROM [User] Inner Join UserRole on [User].UserRoleId = UserRole.UserRoleId WHERE Username = @Username";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryFirstOrDefaultAsync<UserSummaryDbView>(query, new { Username = username }), cancellationToken);
                connection.Close();
                return result;
            }
        }
    }
}