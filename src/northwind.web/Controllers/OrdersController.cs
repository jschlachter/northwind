using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Web.Services;
using Northwind.Web.ViewModels;

namespace Northwind.Web.Controllers
{
    public class OrdersController:Controller
    {
        readonly ILogger _logger;
        readonly IOrderViewModelService _orderViewModelService;

        public OrdersController(ILogger<OrdersController> logger, IOrderViewModelService orderViewModelService)
        {
            _logger = logger;
            _orderViewModelService = orderViewModelService;
        }

        public ActionResult<OrderIndexViewModel> Index(int pageNumber=1, int pageSize=100)
        {
            var orders = _orderViewModelService.GetOrders(pageSize, pageNumber);

            return View(orders);
        }
    }
}
