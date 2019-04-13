using System.Threading.Tasks;
using Northwind.Api.Models;

namespace Northwind.Api.Data
{
    public interface IOrderRepository:IEntityRepository<Order>
    {
        Task<Order> GetByIdWithDetailsAsync(int id);
    }
}
