using Dapper;
using System.Data;

namespace DPSample.SharedCore.Interfaces
{
    public interface IQueryGenericRepository<T, EntityKey> where T : class, IAggregateRoot
    {
        Task<T> FindByKeyAsync(EntityKey Id);
        Task<T> FindByKeyAsync(EntityKey Id, CancellationToken cancellationToken);
        Task<IQueryable<T>> GetAllAsync(List<string>? columns);
        Task<IQueryable<T>> GetAllAsync(List<string>? columns, CancellationToken cancellationToken);
        Task<bool> ExistAsync(EntityKey Id);
        Task<bool> ExistAsync(EntityKey Id, CancellationToken cancellationToken);
        Task<IQueryable<T>> ExecuteCustomQueryAsync(string command, DynamicParameters parms, CommandType commandType = CommandType.Text);
        Task<IQueryable<T>> ExecuteCustomQueryAsync(string command, DynamicParameters parms, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default);
    }
}
