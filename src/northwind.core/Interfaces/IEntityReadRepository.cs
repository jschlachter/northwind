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

    public interface IEntityReadRepository<TEntity, in TId>
        where TEntity : class, IIdentifiable<TId>
    {
        IQueryable<TEntity> Get();
        Task<TEntity> GetAsync(TId id);
        Task<int> CountAsync(IQueryable<TEntity> entities);
    }
}
