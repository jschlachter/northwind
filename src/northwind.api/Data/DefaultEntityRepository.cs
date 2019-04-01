using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Northwind.Api.Models;

namespace Northwind.Api.Data
{
    public class DefaultEntityRepository<TEntity, TId>:IEntityRepository<TEntity, TId>
        where TEntity : class, IIdentifiable<TId>
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public DefaultEntityRepository(ILogger<DefaultEntityRepository<TEntity, TId>> logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetAsync(TId id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> CountAsync(IQueryable<TEntity> entities)
        {
            return (entities is IAsyncEnumerable<TEntity>)
                 ? await entities.CountAsync()
                 : entities.Count();
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            var entity = await GetAsync(id);

            if ( entity == null ) { return false; }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<TEntity> UpdateAsync(TId id, TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
