using System;
using System.Linq.Expressions;
using Northwind.Core.Entities;

namespace Northwind.Core.Specifications
{
    public class OrderFilterSpecification : BaseSpecification<Order>
    {
        public OrderFilterSpecification(string customerId)
            : base(o => string.IsNullOrEmpty(customerId) || o.CustomerId == customerId)
        {
        }
    }
}
