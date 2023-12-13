using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.ClientAdd
{
    public class AddClientCommand : IRequestHandler<AddClientRequest, AddClientResponse>
    {
        readonly AddClientResponse response = new AddClientResponse();
        readonly IClientRepository _repository;

        public AddClientCommand(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddClientResponse> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            try
            {

                if(request.ClientType == Domain.Enum.EClientType.PF &&
                    !CpfUtil.IsValidCpf(request.Document))
                {
                    response.Messages.Add(MessagesConstant.InvalidCpf);
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    
                    return response;
                }
                else if(request.ClientType == Domain.Enum.EClientType.PJ && 
                    !CnpjUtil.IsValidCnpj(request.Document))
                {
                    response.Messages.Add(MessagesConstant.InvalidCnpj);
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return response;
                }

                if (request.ClientType == Domain.Enum.EClientType.PF)
                {
                    var clientExists = await _repository.HasClientWithCpf(request.Document);
                    if (clientExists)
                    {
                        response.Messages.Add(string.Format(MessagesConstant.ClientAlreadyExistsWithCpf, request.Document));
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }
                }
                else
                {
                    var clientExists = await _repository.HasClientWithCnpj(request.Document);
                    if (clientExists)
                    {
                        response.Messages.Add(string.Format(MessagesConstant.ClientAlreadyExistsWithCnpj, request.Document));
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }
                }

                var newClient = AddClientRequest.MapToEntitie(request);
                
                await _repository.AddAsync(newClient);

                response.Client = new Domain.DTOs.Client.ClientDto
                {
                    Id = newClient.Id,
                    Name = newClient.Name,
                    Cpf = newClient.Cpf,
                    Cnpj = newClient.Cnpj,
                    Active = newClient.Active,
                };

                response.StatusCode = System.Net.HttpStatusCode.Created;
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
