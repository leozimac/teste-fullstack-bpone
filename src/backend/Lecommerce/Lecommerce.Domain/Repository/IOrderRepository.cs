using Lecommerce.Domain.DTOs.Order;
using Lecommerce.Domain.Entities;

namespace Lecommerce.Domain.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IList<OrderResumeDto>> GetAllOrdersAsync();
        Task<OrderDetailDto> GetOrderDetailsAsync(Guid id);
    }
}
