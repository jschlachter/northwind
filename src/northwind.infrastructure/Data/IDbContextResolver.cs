using Microsoft.EntityFrameworkCore;

namespace Northwind.Infrastructure.Data
{
    public interface IDbContextResolver
    {
        DbContext GetContext();
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity:class;
    }
}
