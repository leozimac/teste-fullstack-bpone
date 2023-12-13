using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Repository;
using Lecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Lecommerce.Infra.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(LecommerceContext context) : base(context)
        {
        }

        public async Task DeleteRangeAsync(List<OrderItem> orderItems)
        {
            _context.Items.RemoveRange(orderItems);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderItem>> GetByOrderIdAsync(Guid orderId)
        {
            return await _context.Items
                .Where(i => i.OrderId == orderId)
                .ToListAsync();
        }
    }
}
