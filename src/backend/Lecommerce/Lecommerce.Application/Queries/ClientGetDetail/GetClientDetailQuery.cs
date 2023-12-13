using Lecommerce.Domain.Constant;
using Lecommerce.Domain.DTOs.Client;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Queries.ClientGetDetail
{
    public class GetClientDetailQuery : IRequestHandler<GetClientDetailRequest, GetClientDetailResponse>
    {
        readonly GetClientDetailResponse response = new GetClientDetailResponse();
        readonly IClientRepository _repository;

        public GetClientDetailQuery(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetClientDetailResponse> Handle(GetClientDetailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var client = await _repository.GetByIdAsync(request.id);

                if (client == null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.ClientNotFoundWithId, request.id));
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                    return response;
                }

                response.Client = new ClientDto
                {
                    Id = client.Id,
                    Name = client.Name,
                    Cpf = client.Cpf ?? "",
                    Cnpj = client.Cnpj ?? "",
                    Active = client.Active,
                };

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
