namespace Lecommerce.Domain.DTOs.OrderItem
{
    public class AddOrdemItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
