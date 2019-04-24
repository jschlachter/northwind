using System;
using System.Linq.Expressions;
using Northwind.Core.Entities;

namespace Northwind.Core.Specifications
{
    public class CustomerOrdersWithDetailsSpecification : BaseSpecification<Order>
    {
        public CustomerOrdersWithDetailsSpecification(string customerId)
            : base(o => string.IsNullOrEmpty(customerId) || o.CustomerId == customerId)
        {
            AddInclude(o => o.Details);
            AddInclude($"{nameof(Order.Details)}.{nameof(OrderDetail.Product)}");
        }
    }
}
