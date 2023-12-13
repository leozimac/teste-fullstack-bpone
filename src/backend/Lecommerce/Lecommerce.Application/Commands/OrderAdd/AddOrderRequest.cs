using Lecommerce.Domain.DTOs.OrderItem;
using MediatR;

namespace Lecommerce.Application.Commands.OrderAdd
{
    public class AddOrderRequest : IRequest<AddOrderResponse>
    {
        public Guid ClientId { get; set; }
        public List<AddOrdemItemDto> Items { get; set; }
    }
}
