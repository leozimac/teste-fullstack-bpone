using Lecommerce.Domain.DTOs;

namespace Lecommerce.Application.Commands.OrderAdd
{
    public class AddOrderResponse : ResponseBase
    {
        public Guid Id { get; set; }
    }
}
