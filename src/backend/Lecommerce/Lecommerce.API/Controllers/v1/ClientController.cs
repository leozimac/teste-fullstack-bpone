using Asp.Versioning;
using Lecommerce.API.Controllers.shared;
using Lecommerce.Application.Commands.ClientAdd;
using Lecommerce.Application.Commands.ClientDelete;
using Lecommerce.Application.Commands.ClientUpdate;
using Lecommerce.Application.Queries.ClientGetAll;
using Lecommerce.Application.Queries.ClientGetDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lecommerce.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : ApiControllerBase
    {
        public IMediator Mediator { get; set; }

        public ClientController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Busca todos os clientes cadastrados.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna uma lista com todos os clientes cadastrados.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(GetAllClientsResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetAllClientsResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<GetAllClientsResponse> GetAllAsync()
        {
            var request = new GetAllClientsRequest();
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Busca um cliente pelo seu Id.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna os detalhes de um cliente.</response>
        /// <response code="404">Retorna se o cliente não for encontrado.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(GetClientDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetClientDetailResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetClientDetailResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<GetClientDetailResponse> GetDetailAsync([FromRoute] GetClientDetailRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <remarks>
        /// Tipo do cliente:
        /// 
        ///     0 = Pessoa física, informar CPF no campo documento.
        ///     1 = Pessoa jurídica, informar CNPJ no campo documento.
        ///     
        /// </remarks>
        /// <returns></returns>
        /// <response code="201">Cliente criado com sucesso.</response>
        /// <response code="400">Retorna os parâmetros que estão inválidos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(AddClientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AddClientResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AddClientResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<AddClientResponse> AddAsync([FromBody] AddClientRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Atualiza um cliente.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Cliente atualizado com sucesso.</response>
        /// <response code="400">Retorna os parâmetros que estão inválidos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(UpdateClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UpdateClientResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UpdateClientResponse), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<UpdateClientResponse> UpdateAsync([FromBody] UpdateClientRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Desativa um cliente.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Cliente desativado com sucesso.</response>
        /// <response code="400">Retorna o parâmetro que está inválido.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(DeleteClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DeleteClientResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DeleteClientResponse), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<DeleteClientResponse> DeleteAsync([FromRoute] DeleteClientRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }
    }
}
