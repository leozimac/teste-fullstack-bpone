using Asp.Versioning;
using Lecommerce.API.Controllers.shared;
using Lecommerce.Application.Commands.ProductAdd;
using Lecommerce.Application.Commands.ProductDelete;
using Lecommerce.Application.Commands.ProductUpdate;
using Lecommerce.Application.Queries.ProductGetAll;
using Lecommerce.Application.Queries.ProductGetDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lecommerce.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : ApiControllerBase
    {
        public IMediator Mediator { get; set; }

        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Busca todos os produtos cadastrados.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna uma lista com todos os produtos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(GetAllProductsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetAllProductsResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<GetAllProductsResponse> GetAllAsync()
        {
            var request = new GetAllProductsRequest();
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Busca os detalhes de um produto pelo seu Id.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna os detalhes de um produto.</response>
        /// <response code="404">Retorna que o produto não foi encontrado, com o Id informado.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(GetProductDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetProductDetailsResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetProductDetailsResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<GetProductDetailsResponse> GetProductDetailsAsync([FromRoute] GetProductDetailRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Adiciona um novo produto.
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Produto criado com sucesso.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(AddProductResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AddProductResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<AddProductResponse> AddProductAsync([FromBody] AddProductRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Atualiza um produto.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Produto atualizado com sucesso.</response>
        /// <response code="400">Retorna os parâmetros que estão inválidos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<UpdateProductResponse> UpdateProductAsync([FromBody] UpdateProductRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Desativa um produto.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Produto desativado com sucesso.</response>
        /// <response code="400">Retorna os parâmetros que estão invalidos.</response>
        /// <response code="500">Retorna os erros que ocorreram.</response>
        [ProducesResponseType(typeof(DeleteProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DeleteProductResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DeleteProductResponse), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<DeleteProductResponse> DeleteProductAsync([FromRoute] DeleteProductRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }
    }
}
