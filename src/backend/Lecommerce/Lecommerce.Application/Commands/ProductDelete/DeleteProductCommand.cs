using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.ProductDelete
{
    public class DeleteProductCommand : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        readonly DeleteProductResponse response = new DeleteProductResponse();
        readonly IProductRepository _repository;

        public DeleteProductCommand(IProductRepository productRepository)
        {
            _repository =  productRepository;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetByIdAsync(request.id);
                
                if (product is null)
                {
                    response.Messages.Add(String.Format(MessagesConstant.ProductNotFoundWithId, request.id));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    
                    return response;
                }

                product.SetDeleted();
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
