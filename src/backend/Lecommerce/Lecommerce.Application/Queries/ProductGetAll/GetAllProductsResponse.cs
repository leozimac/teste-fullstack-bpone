using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Product;

namespace Lecommerce.Application.Queries.ProductGetAll
{
    public class GetAllProductsResponse : ResponseBase
    {
        public List<ProductResumeDto> Products { get; set; }
    }
}
