using Asp.Versioning;
using Lecommerce.API.Controllers.shared;
using Lecommerce.Application.Commands.OrderAdd;
using Lecommerce.Application.Commands.OrderDelete;
using Lecommerce.Application.Queries.OrderGetAll;
using Lecommerce.Application.Queries.OrderGetDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lecommerce.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderController : ApiControllerBase
    {
        public IMediator Mediator;

        public OrderController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Busca todos os pedidos cadastrados.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna uma lista com todos os pedidos cadastrados.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(GetAllOrdersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetAllOrdersResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<GetAllOrdersResponse> GetAllAsync()
        {
            var request = new GetAllOrdersRequest();

            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Busca um pedido pelo seu Id.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna os detalhes de um pedido.</response>
        /// <response code="400">Retorna os parâmetros que estão inválidos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(GetOrderDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetOrderDetailResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GetOrderDetailResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<GetOrderDetailResponse> GetOrderDetailAsync([FromRoute] GetOrderDetailRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Adiciona um novo pedido.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Pedido criado com sucesso.</response>
        /// <response code="400">Retorna os parâmetros que estão inválidos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(AddOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AddOrderResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AddOrderResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<AddOrderResponse> AddOrderAsync([FromBody] AddOrderRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Remove um pedido.
        /// </summary>
        /// <returns></returns>
        /// <response code="204">Pedido removido com sucesso.</response>
        /// <response code="400">Retorna os parâmetros que estão inválidos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(DeleteOrderResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(DeleteOrderResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DeleteOrderResponse), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<DeleteOrderResponse> DeleteOrderAsync([FromRoute] DeleteOrderRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }
    }
}
