using Lecommerce.Domain.DTOs;
using Lecommerce.Domain.DTOs.Client;

namespace Lecommerce.Application.Commands.ClientAdd
{
    public class AddClientResponse : ResponseBase
    {
        public ClientDto Client { get; set; }
    }
}
