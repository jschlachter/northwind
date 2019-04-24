using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Entities;

namespace Northwind.Core.Interfaces
{
    public interface IEntityRepository<TEntity>
    : IEntityRepository<TEntity, int>
    where TEntity: class, IIdentifiable<int>
    { }

    public interface IEntityRepository<TEntity,TId>
    : IEntityReadRepository<TEntity, TId>
    where TEntity: class, IIdentifiable<TId>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TId id);
        Task<TEntity> UpdateAsync(TId id, TEntity entity);
    }
}
