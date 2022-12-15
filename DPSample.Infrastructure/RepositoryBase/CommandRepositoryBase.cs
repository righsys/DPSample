using DPSample.SharedCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DPSample.Infrastructure.RepositoryBase
{
    public class CommandRepositoryBase<T> : ICommandGenericRepository<T> where T : class, IAggregateRoot
    {
        private readonly DbContext _dbContext;
        public CommandRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<T> AddAsync(T entity)
        {
            return await AddAsync(entity, CancellationToken.None);
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await DeleteAsync(entity, CancellationToken.None);
        }
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Entry(entity).State = EntityState.Deleted;
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity)
        {
            await UpdateAsync(entity, CancellationToken.None);
        }
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            //_dbContext.Entry(entity).State = EntityState.Detached;
        }
    }
}