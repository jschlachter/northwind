using System.Threading.Tasks;
using Northwind.Core.Entities;

namespace Northwind.Core.Interfaces
{
    public interface IOrderRepository:IEntityRepository<Order>
    {
        Task<Order> GetByIdWithDetailsAsync(int id);
    }
}
