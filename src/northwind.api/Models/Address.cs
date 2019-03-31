using System;

namespace Northwind.Api.Models 
{
    public class Address 
    {
        public string Street1 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}