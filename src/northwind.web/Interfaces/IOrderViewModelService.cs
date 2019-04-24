using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Web.ViewModels;

namespace Northwind.Web.Services
{
    public interface IOrderViewModelService
    {
        Task<OrderIndexViewModel> GetOrders(int pageSize, int pageNubmer);
        Task<IEnumerable<SelectListItem>> GetCustomers();
    }
}
