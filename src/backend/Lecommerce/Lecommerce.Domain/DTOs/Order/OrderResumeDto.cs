namespace Lecommerce.Domain.DTOs.Order
{
    public class OrderResumeDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}
