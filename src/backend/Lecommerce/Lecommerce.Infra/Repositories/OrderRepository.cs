using Lecommerce.Domain.DTOs.Order;
using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Repository;
using Lecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Lecommerce.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(LecommerceContext context) : base(context)
        {
        }

        public async Task<IList<OrderResumeDto>> GetAllOrdersAsync()
        {
            var result = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Items)
                .Select(o => new OrderResumeDto
                {
                    Id = o.Id,
                    Code = o.Code,
                    Date = o.CreationDate,
                    Client = o.Client.Name,
                    Total = o.Items.Sum(i => i.Total)
                }).ToListAsync();

            return result;
        }

        public async Task<OrderDetailDto> GetOrderDetailsAsync(Guid id)
        {
            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return null;

            var orderTotal = order.Items.Sum(i => i.Total);

            var orderDetails = new OrderDetailDto
            {
                Id = order.Id,
                Code = order.Code,
                Date = order.CreationDate,
                Total = orderTotal,
                Client = order.Client.Name,
                Items = new List<Domain.DTOs.OrderItem.OrderItemDto>()
            };

            foreach(var item in order.Items)
            {
                orderDetails.Items.Add(new Domain.DTOs.OrderItem.OrderItemDto
                {
                    Product = item.Product.Name,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,
                    Total = item.Total
                });
            }

            return orderDetails;
        }
    }
}
