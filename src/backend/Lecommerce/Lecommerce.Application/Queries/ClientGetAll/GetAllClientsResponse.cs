using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Client;

namespace Lecommerce.Application.Queries.ClientGetAll
{
    public class GetAllClientsResponse : ResponseBase
    {
        public List<ClientDto> Clients { get; set; } = new List<ClientDto>();
    }
}
