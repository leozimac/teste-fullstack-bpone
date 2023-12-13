using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Order;

namespace Lecommerce.Application.Queries.OrderGetDetail
{
    public class GetOrderDetailResponse : ResponseBase
    {
        public OrderDetailDto Order { get; set; }
    }
}
