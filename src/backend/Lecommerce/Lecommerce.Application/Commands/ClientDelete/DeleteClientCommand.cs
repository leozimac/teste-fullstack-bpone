using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.ClientDelete
{
    public class DeleteClientCommand : IRequestHandler<DeleteClientRequest, DeleteClientResponse>
    {
        readonly DeleteClientResponse response = new DeleteClientResponse();
        readonly IClientRepository _repository;

        public DeleteClientCommand(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteClientResponse> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var client = await _repository.GetByIdAsync(request.id);

                if (client == null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.ClientNotFoundWithId, request.id));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return response;
                }

                client.Deletion();
                await _repository.UpdateAsync(client);

                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.GetAllMessages());
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
