using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Web.ViewModels;

namespace Northwind.Web.Services
{
    public interface IProductViewModelService
    {
        Task<ProductIndexViewModel> GetProducts(int pageSize, int pageNumber);
        Task<IEnumerable<SelectListItem>> GetCategories();
        Task<IEnumerable<SelectListItem>> GetSuppliers();
    }
}
