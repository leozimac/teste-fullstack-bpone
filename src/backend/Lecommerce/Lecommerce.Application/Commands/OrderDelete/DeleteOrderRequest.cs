using MediatR;

namespace Lecommerce.Application.Commands.OrderDelete
{
    public class DeleteOrderRequest : IRequest<DeleteOrderResponse>
    {
        public Guid id { get; set; }
    }
}
