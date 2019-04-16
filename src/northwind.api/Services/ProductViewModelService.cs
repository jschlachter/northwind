using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.ViewModels;
using Northwind.Core.Entities;
using Northwind.Core.Interfaces;

namespace Northwind.Api.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        IEntityRepository<Product, int> _productRepository;
        IEntityRepository<Category, int> _categoryRepository;


        public ProductViewModelService(
            IEntityRepository<Product, int> productRepository,
            IEntityRepository<Category, int> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
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

        public async Task<ProductIndexViewModel> GetProducts(int pageSize, int pageNumber)
        {
            var products = _productRepository.Get();
            var page = await _productRepository.PageAsync(products, pageSize, pageNumber);
            var totalItems = await _productRepository.CountAsync(products);

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