using System;

namespace Northwind.Core.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public Address Address { get; set;}
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
