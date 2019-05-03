using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Web.ViewModels;
using Northwind.Core.Entities;
using Northwind.Core.Interfaces;
using Northwind.Core.Specifications;

namespace Northwind.Web.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        IEntityRepository<Product, int> _productRepository;
        IEntityRepository<Category, int> _categoryRepository;
        IEntityRepository<Supplier, int> _supplierRepository;

        public ProductViewModelService(
            IEntityRepository<Product, int> productRepository,
            IEntityRepository<Category, int> categoryRepository,
            IEntityRepository<Supplier, int> supplierRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            var categories = await _categoryRepository.Get().ToListAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem { Value = null, Text = "All", Selected = true }
            };

            foreach(var category in categories)
            {
                items.Add(new SelectListItem { Value=category.StringId,  Text=category.Name});
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetSuppliers()
        {
            var suppliers = await _supplierRepository.Get().ToListAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem { Value=null, Text="All", Selected=true }
            };

            foreach(var supplier in suppliers)
            {
                items.Add(new SelectListItem { Value=supplier.StringId, Text=supplier.CompanyName});
            }

            return items;
        }

        public async Task<ProductIndexViewModel> GetProducts(int pageSize, int pageNumber)
        {
            var filter = new ProductFilterPaginatedSpecification(pageSize * pageNumber, pageSize, null, null);
            var page = await _productRepository.ListAsync(filter);
            var totalItems = await _productRepository.CountAsync(new ProductFilterSpecification());

            var vm = new ProductIndexViewModel
            {
                Products = page.Select(i => new ProductViewModel{
                    ProductId = i.Id,
                    ProductName = i.Name,
                    QuantityPerUnit = i.QuantityPerUnit,
                    UnitPrice = i.UnitPrice,
                    Discontinued = i.Discontinued,
                    UnitsInStock = i.UnitsInStock
                }),
                Categories = await GetCategories(),
                Suppliers = await GetSuppliers(),
                PaginationInfo = new PaginationInfoViewModel {
                    ItemsPerPage = page.Count(),
                    PageNumber = pageNumber,
                    TotalItems = totalItems
                }
            };

            return vm;
        }
    }
}
