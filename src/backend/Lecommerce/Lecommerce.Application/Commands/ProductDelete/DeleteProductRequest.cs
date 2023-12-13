using MediatR;

namespace Lecommerce.Application.Commands.ProductDelete
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public Guid id { get; set; }
    }
}
