using Lecommerce.Domain.DTOs.Product;
using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Repository;
using Lecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Lecommerce.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(LecommerceContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllActiveAsync()
        {
            return await _context.Products.Where(p => p.Active).ToListAsync();
        }

        public async Task<List<ProductResumeDto>> GetAllProductsResumeAsync()
        {
            return await _context.Products
                .Where(p => p.Active)
                .Select(p => new ProductResumeDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Price = p.Price
                }).ToListAsync();
        }

        public async Task<bool> HasProductWithCode(int code)
        {
            return await _context.Products.AnyAsync(p => p.Code == code);
        }

        public async Task<ProductDetailDto?> GetProductDetailsAsync(Guid id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return null;

            var productDetail = new ProductDetailDto
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Price = product.Price,
                Active = product.Active,
                CreationDate = product.CreationDate,
                UpdateDate = product.UpdateDate,
            };

            return productDetail;
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.SaveChangesAsync();
        }
    }
}
