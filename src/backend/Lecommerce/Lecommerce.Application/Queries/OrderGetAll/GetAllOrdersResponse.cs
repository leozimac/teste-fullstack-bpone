using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Order;

namespace Lecommerce.Application.Queries.OrderGetAll
{
    public class GetAllOrdersResponse : ResponseBase
    {
        public List<OrderResumeDto> Orders { get; set; }
    }
}
