using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecommerce.Application.Queries.ProductGetAll
{
    public class GetAllProductsQuery : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
    {
        readonly GetAllProductsResponse response = new GetAllProductsResponse();
        readonly IProductRepository _repository;

        public GetAllProductsQuery(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _repository.GetAllProductsResumeAsync();

                if(products is null || products.Count == 0)
                {
                    response.Messages.Add(MessagesConstant.ProductsNotFound);
                    response.StatusCode = System.Net.HttpStatusCode.NoContent;
                    return response;
                }

                response.Products = products;
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
