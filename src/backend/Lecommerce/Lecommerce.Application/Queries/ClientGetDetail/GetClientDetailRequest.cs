using MediatR;

namespace Lecommerce.Application.Queries.ClientGetDetail
{
    public class GetClientDetailRequest : IRequest<GetClientDetailResponse>
    {
        public Guid id { get; set; }
    }
}
