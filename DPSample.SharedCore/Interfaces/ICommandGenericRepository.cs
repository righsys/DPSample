namespace DPSample.SharedCore.Interfaces
{
    public interface ICommandGenericRepository<T> where T : class, IAggregateRoot
    {
        Task DeleteAsync(T entity);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<T> AddAsync(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    }
}
