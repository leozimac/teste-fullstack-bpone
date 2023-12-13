using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Product;

namespace Lecommerce.Application.Commands.ProductAdd
{
    public class AddProductResponse : ResponseBase
    {
        public ProductDetailDto Product { get; set; }
    }
}
