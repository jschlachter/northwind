using System.Linq;
using System.Threading.Tasks;
using Northwind.Api.Models;

namespace Northwind.Api.Data
{
    public interface IEntityRepository<TEntity, TId>
    where TEntity : class, IIdentifiable<TId>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        IQueryable<TEntity> Get();
        Task<TEntity> GetAsync(TId id);
        Task<int> CountAsync(IQueryable<TEntity> entities);
        Task<bool> DeleteAsync(TId id);
        Task<TEntity> UpdateAsync(TId id, TEntity entity);
    }
}
