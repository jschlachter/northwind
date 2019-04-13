namespace Northwind.Api.Models
{
    public class OrderDetail
    {
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public decimal ExtendedPrice
        {
            get
            {
                return (UnitPrice * Quantity * (decimal)((1 - Discount)/100)) * 100;
            }
        }
    }
}
