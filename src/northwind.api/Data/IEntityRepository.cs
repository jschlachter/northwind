using System.Linq;
using System.Threading.Tasks;
using Northwind.Api.Models;

namespace Northwind.Api.Data
{
    public interface IEntityRepository<TEntity>
    : IEntityRepository<TEntity, int>, IEntityReadRepository<TEntity, int>
    where TEntity: class, IIdentifiable<int>
    { }

    public interface IEntityRepository<TEntity, in TId>
    : IEntityReadRepository<TEntity, TId>
    where TEntity: class, IIdentifiable<TId>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TId id);
        Task<TEntity> UpdateAsync(TId id, TEntity entity);
    }
}
