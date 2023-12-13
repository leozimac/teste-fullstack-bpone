namespace Lecommerce.Domain.DTOs.OrderItem
{
    public class OrderItemDto
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
