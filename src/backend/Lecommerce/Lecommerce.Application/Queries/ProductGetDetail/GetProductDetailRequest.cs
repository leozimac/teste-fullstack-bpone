using MediatR;

namespace Lecommerce.Application.Queries.ProductGetDetail
{
    public class GetProductDetailRequest : IRequest<GetProductDetailsResponse>
    {
        public Guid id { get; set; }
    }
}
