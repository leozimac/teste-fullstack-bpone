using Lecommerce.Domain.DTOs.Product;
using Lecommerce.Domain.Entities;

namespace Lecommerce.Domain.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllActiveAsync();
        Task<List<ProductResumeDto>> GetAllProductsResumeAsync();
        Task<ProductDetailDto?> GetProductDetailsAsync(Guid id);
        Task<bool> HasProductWithCode(int code);
        Task UpdateAsync(Product product);
    }
}
