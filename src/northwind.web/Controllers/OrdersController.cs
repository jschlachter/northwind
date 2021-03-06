using System;
using System.Threading.Tasks;
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

        public async Task<ActionResult<OrderIndexViewModel>> Index()
        {
            var accept =  HttpContext.Request.Headers["Accept"];
            var orders = await _orderViewModelService.GetOrders(10, 0);

            switch(accept.ToString())
            {
                case "application/json":
                    return Json(orders);
                default:
                    return View(orders);
            }
        }
    }
}
