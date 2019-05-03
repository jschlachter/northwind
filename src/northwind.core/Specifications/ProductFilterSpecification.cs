using System;
using Northwind.Core.Entities;

namespace Northwind.Core.Specifications
{
    public class ProductFilterSpecification : BaseSpecification<Product>
    {
        public ProductFilterSpecification() : this(null, null)
        {
        }

        public ProductFilterSpecification (int? supplierId, int? categoryId)
            : base (product => (product.Supplier.Id == supplierId) &&
                               (product.Category.Id == categoryId))
            {
            }
    }
}
