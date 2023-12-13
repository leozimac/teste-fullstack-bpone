using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.ProductUpdate
{
    public class UpdateProductCommand : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        readonly UpdateProductResponse response = new UpdateProductResponse();
        readonly IProductRepository _repository;

        public UpdateProductCommand(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetByIdAsync(request.Id);

                if (product is null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.ProductNotFoundWithId, request.Id));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return response;
                }

                product.UpdateProperties(request.Name, request.Code, request.Price);
                await _repository.UpdateAsync(product);

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
