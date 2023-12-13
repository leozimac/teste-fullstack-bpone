using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Client;

namespace Lecommerce.Application.Queries.ClientGetDetail
{
    public class GetClientDetailResponse : ResponseBase
    {
        public ClientDto Client { get; set; }
    }
}
