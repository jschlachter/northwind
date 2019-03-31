using System;

namespace Northwind.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Shipper Shipper { get; set; }
        public decimal Freight { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
