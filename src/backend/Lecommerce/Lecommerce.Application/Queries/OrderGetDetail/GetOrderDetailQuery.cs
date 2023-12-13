using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecommerce.Application.Queries.OrderGetDetail
{
    public class GetOrderDetailQuery : IRequestHandler<GetOrderDetailRequest, GetOrderDetailResponse>
    {
		readonly GetOrderDetailResponse response = new GetOrderDetailResponse();
		readonly IOrderRepository _repository;

        public GetOrderDetailQuery(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailResponse> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken)
        {
			try
			{
                var order = await _repository.GetOrderDetailsAsync(request.id);

                if(order is null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.OrderNotFoundWithId, request.id));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return response;
                }

                response.Order = order;
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
