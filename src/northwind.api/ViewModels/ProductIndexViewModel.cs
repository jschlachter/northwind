using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Northwind.Api.ViewModels
{
    public class ProductIndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
