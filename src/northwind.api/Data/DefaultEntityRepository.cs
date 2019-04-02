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
        private readonly ILogger _logger;
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public DefaultEntityRepository(ILogger<DefaultEntityRepository<TEntity, TId>> logger, DbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
            _dbSet = dbContext.Set<TEntity>();

        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            return await Get().SingleOrDefaultAsync(e=>e.Id.Equals(id));
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

        public async Task<TEntity> UpdateAsync(TId id, TEntity entity)
        {
            var oldEntity = await GetAsync(id);

            if( oldEntity == null) {
                return null;
            }

            var modifiedProperties = _context.Entry(entity).Properties.Where(p => p.IsModified);
            foreach(var modifiedProperty in modifiedProperties)
            {
                var propertyName = modifiedProperty.Metadata.PropertyInfo.Name;
                var property = _context.Entry(oldEntity).Property(propertyName);

                property.Metadata.PropertyInfo.SetValue(oldEntity, modifiedProperty.CurrentValue);
            }
            await _context.SaveChangesAsync();
            return oldEntity;
        }
    }
}
