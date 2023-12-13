using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.ClientUpdate
{
    public class UpdateClientCommand : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
    {
        readonly UpdateClientResponse response = new UpdateClientResponse();
        readonly IClientRepository _repository;

        public UpdateClientCommand(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var client = await _repository.GetByIdAsync(request.Id);

                if (client == null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.ClientNotFoundWithId, request.Id));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return response;
                }

                var isCpf = request.ClientType == Domain.Enum.EClientType.PF;

                if (isCpf &&
                    !CpfUtil.IsValidCpf(request.Document))
                {
                    response.Messages.Add(MessagesConstant.InvalidCpf);
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return response;
                }
                else if (!isCpf && !CnpjUtil.IsValidCnpj(request.Document))
                {
                    response.Messages.Add(MessagesConstant.InvalidCnpj);
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return response;
                }

                if (request.ClientType == Domain.Enum.EClientType.PF && request.Document != client.Cpf)
                {
                    var clientExists = await _repository.HasClientWithCpf(request.Document);
                    if (clientExists)
                    {
                        response.Messages.Add(string.Format(MessagesConstant.ClientAlreadyExistsWithCpf, request.Document));
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }
                }
                else if (request.ClientType == Domain.Enum.EClientType.PJ && request.Document != client.Cnpj)
                {
                    var clientExists = await _repository.HasClientWithCnpj(request.Document);
                    if (clientExists)
                    {
                        response.Messages.Add(string.Format(MessagesConstant.ClientAlreadyExistsWithCnpj, request.Document));
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }
                }

                client.Update(request.Name, request.Document, isCpf);
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
