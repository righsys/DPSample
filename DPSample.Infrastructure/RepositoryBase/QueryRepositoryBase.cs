using Dapper;
using DPSample.Infrastructure.DbContexts;
using DPSample.SharedCore.Interfaces;
using System.Data;

namespace DPSample.Infrastructure.RepositoryBase
{
    public class QueryRepositoryBase<T, EntityKey> : IQueryGenericRepository<T, EntityKey> where T : class, IAggregateRoot
    {
        private readonly QueryDbContext _queryDbContext;

        public QueryRepositoryBase(QueryDbContext queryDbContext)
        {
            _queryDbContext = queryDbContext;
        }

        //
        // ExecuteCustomQueryAsync
        //
        public async Task<IQueryable<T>> ExecuteCustomQueryAsync(string command, DynamicParameters? parms = null,
            CommandType commandType = CommandType.Text)
        {
            return await ExecuteCustomQueryAsync(command, parms, commandType, CancellationToken.None);
        }

        public async Task<IQueryable<T>> ExecuteCustomQueryAsync(string command, DynamicParameters? parms = null,
            CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
        {
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection
                     .QueryAsync(command, parms, null, null, commandType), cancellationToken);
                connection.Close();
                return (IQueryable<T>)result;
            }
        }

        //
        // ExistAsync
        //
        public async Task<bool> ExistAsync(EntityKey Id)
        {
            return await ExistAsync(Id, CancellationToken.None);
        }
        public async Task<bool> ExistAsync(EntityKey Id, CancellationToken cancellationToken)
        {
            string entityName = typeof(T).Name;
            string idName = entityName + "Id";
            string query = $"Select {idName} From {entityName} where {entityName}.{idName} = @Id";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryFirstOrDefaultAsync<T>(query, new { Id = Id }), cancellationToken);
                connection.Close();
                return result is not null;
            }
        }

        //
        // FindByKeyAsync
        //
        public async Task<T> FindByKeyAsync(EntityKey Id)
        {
            return await FindByKeyAsync(Id, CancellationToken.None);
        }
        public async Task<T> FindByKeyAsync(EntityKey Id, CancellationToken cancellationToken)
        {
            string entityName = typeof(T).Name;
            string idName = entityName + "Id";
            string query = $"SELECT * FROM [{entityName}] WHERE [{entityName}].{idName} = @Id";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryFirstOrDefaultAsync<T>(query, new { Id = Id }), cancellationToken);
                connection.Close();
                return result;
            }
        }

        //
        // GetAllAsync
        //
        public async Task<IQueryable<T>> GetAllAsync(List<string>? columns)
        {
            return await GetAllAsync(columns, CancellationToken.None);
        }
        public async Task<IQueryable<T>> GetAllAsync(List<string>? columns, CancellationToken cancellationToken)
        {
            string entityName = typeof(T).Name;
            string query = "";
            query = $"SELECT * FROM [{entityName}]";
            if (columns is not null)
                query = $"SELECT {string.Join(",", columns)} FROM [{entityName}]";
            using (var connection = _queryDbContext.CreateConnection())
            {
                connection.Open();
                var result = await Task.Run(() => connection.QueryAsync<T>(query), cancellationToken);
                connection.Close();
                return result.AsQueryable();
            }
        }
    }
}