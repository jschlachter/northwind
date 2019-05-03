using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities;
using Northwind.Core.Interfaces;
using Northwind.Core.Specifications;
using Northwind.Web.ViewModels;

namespace Northwind.Web.Services
{
    public class OrderViewModelService : IOrderViewModelService
    {
        readonly IEntityRepository<Order, int> _orderRepository;
        readonly IEntityRepository<Customer, string> _customerRepository;


        public OrderViewModelService(
            IEntityRepository<Order, int> orderRepository,
            IEntityRepository<Customer, string> customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetCustomers()
        {
            var customers = await _customerRepository.Get().ToListAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem { Value=null, Text="All", Selected=true }
            };

            customers.ForEach(customer =>
            {
                items.Add(new SelectListItem(customer.ContactName, customer.Id));
            });

            return items;
        }

        public async Task<OrderIndexViewModel> GetOrders(int pageSize, int pageNumber)
        {
            var filter = new OrderFilterSpecification(null);
            var filterPaginated = new OrderFilterPaginatedSpecification(pageSize * pageNumber, pageSize, null);
            var orders = await _orderRepository.ListAsync(filterPaginated);

            var totalItems = await _orderRepository.CountAsync(filter);

            var vm = new OrderIndexViewModel
            {
                Orders = orders.Select(o => new OrderViewModel{
                    OrderNumber = o.Id,
                    OrderDate = o.OrderDate,
                    ShippedDate = o.ShippedDate,
                    ShippingAddress = o.ShippingAddress
                }),
                PaginationInfo = new PaginationInfoViewModel{
                    ItemsPerPage = pageSize,
                    PageNumber = pageNumber,
                    TotalItems = totalItems
                }
            };

            return vm;
        }
    }
}
