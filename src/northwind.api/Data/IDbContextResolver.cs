using Microsoft.EntityFrameworkCore;

namespace Northwind.Api.Data
{
    public interface IDbContextResolver
    {
        DbContext GetContext();
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity:class;
    }
}
