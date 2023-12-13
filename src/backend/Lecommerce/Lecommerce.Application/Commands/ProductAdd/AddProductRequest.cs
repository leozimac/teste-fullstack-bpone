using MediatR;

namespace Lecommerce.Application.Commands.ProductAdd
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
    }
}
