using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Api.Models
{
    public class Order : Identifiable
    {
        public Order()
        {
            Details = Enumerable.Empty<OrderDetail>();
        }

        public string CustomerId { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
        public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Shipper Shipper { get; set; }
        public decimal Freight { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
