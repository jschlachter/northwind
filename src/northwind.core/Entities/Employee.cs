using System;

namespace Northwind.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public Address Address { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] ImageData { get; set; }
        public string Notes { get; set; }
        public string PhotoPath { get; set; }
        public Employee Manager { get; set; }
    }
}
