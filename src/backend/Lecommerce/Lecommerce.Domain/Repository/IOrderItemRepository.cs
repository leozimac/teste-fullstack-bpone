using Lecommerce.Domain.Entities;

namespace Lecommerce.Domain.Repository
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task DeleteRangeAsync(List<OrderItem> orderItems);
        Task<List<OrderItem>> GetByOrderIdAsync(Guid orderId);
    }
}
