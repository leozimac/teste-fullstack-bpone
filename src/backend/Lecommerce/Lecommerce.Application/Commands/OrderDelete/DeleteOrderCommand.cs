using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.OrderDelete
{
    public class DeleteOrderCommand : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        readonly DeleteOrderResponse response = new DeleteOrderResponse();
        readonly IOrderRepository _orderRepository;
        readonly IOrderItemRepository _itemRepository;

        public DeleteOrderCommand(IOrderRepository orderRepository, IOrderItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(request.id);

                if (order is null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.OrderNotFoundWithId, request.id));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    
                    return response;
                }

                var orderItems = await _itemRepository.GetByOrderIdAsync(request.id);

                await _itemRepository.DeleteRangeAsync(orderItems);
                await _orderRepository.DeleteAsync(order);

                response.StatusCode = System.Net.HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.GetAllMessages());
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
