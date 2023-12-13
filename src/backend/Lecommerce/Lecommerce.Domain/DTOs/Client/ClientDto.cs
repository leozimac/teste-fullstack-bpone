namespace Lecommerce.Domain.DTOs.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public bool Active { get; set; }
    }
}
