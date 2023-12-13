using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.OrderAdd
{
    public class AddOrderCommand : IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        readonly AddOrderResponse response = new AddOrderResponse();
        readonly IOrderRepository _orderRepository;
        readonly IOrderItemRepository _orderItemRepository;

        public AddOrderCommand(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newOrder = new Order(request.ClientId);

                foreach (var item in request.Items)
                {
                    if(item.Quantity <= 0)
                    {
                        response.Messages.Add(MessagesConstant.ProductQuantityInvalid);
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }

                    newOrder.AddItem(new OrderItem(
                        newOrder.Id,
                        item.ProductId,
                        item.Quantity,
                        item.Total
                        ));
                }

                await _orderRepository.AddAsync(newOrder);

                response.Id = newOrder.Id;
                response.StatusCode = System.Net.HttpStatusCode.Created;
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
