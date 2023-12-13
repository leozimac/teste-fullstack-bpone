using MediatR;

namespace Lecommerce.Application.Commands.ClientDelete
{
    public class DeleteClientRequest : IRequest<DeleteClientResponse>
    {
        public Guid id { get; set; }
    }
}
