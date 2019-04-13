using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Northwind.Api.Models;

namespace Northwind.Api.Data
{
    public class OrderRepository : DefaultEntityRepository<Order>, IOrderRepository
    {
        public OrderRepository(ILogger<DefaultEntityRepository<Order, int>> logger, IDbContextResolver dbContextResolver)
        : base(logger, dbContextResolver)
        {
        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            var query = Get()
                        .Include(o => o.Details)
                        .ThenInclude(detail => detail.Product);

            return await query.SingleOrDefaultAsync(o => o.Id.Equals(id));
        }
    }
}
