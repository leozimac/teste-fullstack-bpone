using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Queries.OrderGetAll
{
    public class GetAllOrdersQuery : IRequestHandler<GetAllOrdersRequest, GetAllOrdersResponse>
    {
        readonly GetAllOrdersResponse response = new GetAllOrdersResponse();
        readonly IOrderRepository _repository;

        public GetAllOrdersQuery(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllOrdersResponse> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _repository.GetAllOrdersAsync();

                if (orders is null || orders.Count == 0)
                {
                    response.Messages.Add(MessagesConstant.OrdersNotFound);
                    response.StatusCode = System.Net.HttpStatusCode.NoContent;
                    return response;
                }

                response.Orders = orders.ToList();
                response.StatusCode = System.Net.HttpStatusCode.OK;
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
