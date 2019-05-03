using Northwind.Core.Entities;

namespace Northwind.Core.Specifications
{
    public class ProductFilterPaginatedSpecification:BaseSpecification<Product>
    {
        public ProductFilterPaginatedSpecification(int skip, int take, int? supplierId, int? categoryId)
            : base (product => (product.Supplier.Id == supplierId) &&
                               (product.Category.Id == categoryId))
        {
            ApplyPaging(skip, take);
        }
    }
}
