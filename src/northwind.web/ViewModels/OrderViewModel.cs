using System;
using Northwind.Core.Entities;

namespace Northwind.Web.ViewModels
{
    public class OrderViewModel
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get ;set; }
        public Address ShippingAddress { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}
