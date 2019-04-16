using System;

namespace Northwind.Core.Entities
{
    public class Category:Identifiable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
    }
}
