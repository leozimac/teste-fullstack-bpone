using Lecommerce.Domain.DTOs.Client;
using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Repository;
using Lecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Lecommerce.Infra.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(LecommerceContext context) : base(context) { }

        public async Task<IEnumerable<ClientDto>> GetAllActiveAsync()
        {
            return await _context.Clients
                .AsNoTracking()
                .Where(c => c.Active)
                .Select(c => new ClientDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Cpf = c.Cpf,
                    Cnpj = c.Cnpj,
                    Active = c.Active
                })
                .ToListAsync();
        }

        public async Task<bool> HasClientWithCnpj(string cnpj)
        {
            return await _context.Clients.AnyAsync(c => c.Cnpj == cnpj);
        }

        public async Task<bool> HasClientWithCpf(string cpf)
        {
            return await _context.Clients.AnyAsync(c => c.Cpf == cpf);
        }

        public async Task UpdateAsync(Client client)
        {
            await _context.SaveChangesAsync();
        }
    }
}
