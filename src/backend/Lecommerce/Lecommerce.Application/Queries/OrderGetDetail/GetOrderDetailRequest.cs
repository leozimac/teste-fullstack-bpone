using MediatR;

namespace Lecommerce.Application.Queries.OrderGetDetail
{
    public class GetOrderDetailRequest : IRequest<GetOrderDetailResponse>
    {
        public Guid id { get; set; }
    }
}
