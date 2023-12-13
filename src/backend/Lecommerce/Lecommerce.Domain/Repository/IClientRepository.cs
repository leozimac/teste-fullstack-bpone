using Lecommerce.Domain.DTOs.Client;
using Lecommerce.Domain.Entities;

namespace Lecommerce.Domain.Repository
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<IEnumerable<ClientDto>> GetAllActiveAsync();
        Task<bool> HasClientWithCpf(string cpf);
        Task<bool> HasClientWithCnpj(string cnpj);
        Task UpdateAsync(Client client);
    }
}
