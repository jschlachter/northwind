using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Api.Models;

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersController(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            throw new NotImplementedException("Method not implemented");
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            throw new NotImplementedException("Method not implemented");
        }
    }
}
