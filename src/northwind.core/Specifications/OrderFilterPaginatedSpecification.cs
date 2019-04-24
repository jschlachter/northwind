using System;
using System.Linq.Expressions;
using Northwind.Core.Entities;

namespace Northwind.Core.Specifications
{
    public class OrderFilterPaginatedSpecification : BaseSpecification<Order>
    {
        public OrderFilterPaginatedSpecification(int skip, int take, string customerId)
            : base(o => string.IsNullOrEmpty(customerId) || o.CustomerId == customerId)
        {
            ApplyPaging(skip, take);
        }
    }
}
