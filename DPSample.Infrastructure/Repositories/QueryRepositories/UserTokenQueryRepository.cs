using Azure.Core;
using Dapper;
using DPSample.Domain.Entities;
using DPSample.Infrastructure.DbContexts;
using DPSample.Infrastructure.RepositoryBase;
using DPSample.Services.Contracts.QueryRepositories;
using System.Threading;

namespace DPSample.Infrastructure.Repositories.QueryRepositories
{
    public class UserTokenQueryRepository:QueryRepositoryBase<UserToken, int>, IUserTokenQueryRepository
    {
        private readonly QueryDbContext _queryDbContext;
        public UserTokenQueryRepository(QueryDbContext queryDbContext) : base(queryDbContext) => _queryDbContext = queryDbContext;

        public async Task<UserToken> GetToken(string accessToken, int userId)
        {            
            string query = $"SELECT * FROM UserToken WHERE UserToken.UserId = @UserId and UserToken.AccessTokenHash = @AccessToken";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryFirstOrDefaultAsync<UserToken>(query, new { UserId = userId, AccessToken=accessToken }), CancellationToken.None);
                connection.Close();
                return result;
            }
        }

        public async Task<List<UserToken>> GetTokens(int userId)
        {
            string query = $"SELECT * FROM UserToken WHERE UserToken.UserId = @UserId";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryAsync<UserToken>(query, new { UserId = userId }), CancellationToken.None);
                connection.Close();
                return result.ToList();
            }
        }
    }
}