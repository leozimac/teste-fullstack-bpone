using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Product;

namespace Lecommerce.Application.Queries.ProductGetDetail
{
    public class GetProductDetailsResponse : ResponseBase
    {
        public ProductDetailDto Product { get; set; }
    }
}
