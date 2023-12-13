namespace Lecommerce.Domain.DTOs.Product
{
    public class ProductResumeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
    }
}
