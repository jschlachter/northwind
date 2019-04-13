using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Northwind.Api.Data;
using Northwind.Api.Models;

namespace Northwind.Api.Services
{
    public class OrderService:IOrderService
    {
        ILogger _logger;
        DefaultEntityRepository<Order> _repository;

        public OrderService(ILogger<OrderService> logger, DefaultEntityRepository<Order> repository)
        {
            _logger = logger;
            _repository = repository;
        }
    }
}
