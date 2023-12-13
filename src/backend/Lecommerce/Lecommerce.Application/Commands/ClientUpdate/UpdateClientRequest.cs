using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Enum;
using MediatR;

namespace Lecommerce.Application.Commands.ClientUpdate
{
    public class UpdateClientRequest : IRequest<UpdateClientResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public EClientType ClientType { get; set; }
    }
}
