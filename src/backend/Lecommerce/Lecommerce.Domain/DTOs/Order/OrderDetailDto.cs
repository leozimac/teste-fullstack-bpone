using Lecommerce.Domain.DTOs.OrderItem;

namespace Lecommerce.Domain.DTOs.Order
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
