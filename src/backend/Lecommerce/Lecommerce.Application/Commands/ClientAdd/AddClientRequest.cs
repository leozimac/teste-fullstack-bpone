using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Enum;
using MediatR;

namespace Lecommerce.Application.Commands.ClientAdd
{
    public class AddClientRequest : IRequest<AddClientResponse>
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public EClientType ClientType { get; set; }

        public static Client MapToEntitie(AddClientRequest request)
        {
            var isCpf = request.ClientType == EClientType.PF;

            return new Client(request.Name, request.Document, isCpf);
        }
    }
}
