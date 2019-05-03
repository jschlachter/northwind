using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Entities;

namespace Northwind.Core.Interfaces
{
    public interface IEntityReadRepository<TEntity>
        : IEntityReadRepository<TEntity, int>
        where TEntity: class, IIdentifiable<int>
    {
    }

    public interface IEntityReadRepository<TEntity, TId>
        where TEntity : class, IIdentifiable<TId>
    {
        IQueryable<TEntity> Get();
        Task<TEntity> GetAsync(TId id);
        Task<int> CountAsync(ISpecification<TEntity, TId> spec);
        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity, TId> spec);
    }
}
