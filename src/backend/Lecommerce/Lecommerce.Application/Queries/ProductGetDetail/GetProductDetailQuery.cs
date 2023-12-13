using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecommerce.Application.Queries.ProductGetDetail
{
    public class GetProductDetailQuery : IRequestHandler<GetProductDetailRequest, GetProductDetailsResponse>
    {
        readonly GetProductDetailsResponse response = new GetProductDetailsResponse();
        readonly IProductRepository _repository;

        public GetProductDetailQuery(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<GetProductDetailsResponse> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetProductDetailsAsync(request.id);

                if(product is null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.ProductNotFoundWithId, request.id));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    
                    return response;
                }

                response.Product = product;
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
