using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Core.Entities;

namespace Northwind.Web.ViewModels
{
    public class OrderIndexViewModel
    {
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
