using MediatR;

namespace Lecommerce.Application.Commands.ProductUpdate
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
    }
}
