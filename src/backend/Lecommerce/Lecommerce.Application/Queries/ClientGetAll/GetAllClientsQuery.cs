using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Queries.ClientGetAll
{
    public class GetAllClientsQuery : IRequestHandler<GetAllClientsRequest, GetAllClientsResponse>
    {
        readonly GetAllClientsResponse response = new GetAllClientsResponse();
        readonly IClientRepository _repository;

        public GetAllClientsQuery(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllClientsResponse> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var clients = await _repository.GetAllActiveAsync();

                if (clients is null || !clients.Any())
                {
                    response.StatusCode = System.Net.HttpStatusCode.NoContent;
                    response.Messages.Add(MessagesConstant.ClientNotFound);
                    return response;
                }

                response.Clients = clients.ToList();
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
