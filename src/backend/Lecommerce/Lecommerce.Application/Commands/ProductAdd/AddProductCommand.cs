using Lecommerce.Domain.Constant;
using Lecommerce.Domain.Entities;
using Lecommerce.Domain.Repository;
using Lecommerce.Domain.Utils;
using MediatR;

namespace Lecommerce.Application.Commands.ProductAdd
{
    public class AddProductCommand : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        readonly AddProductResponse response = new AddProductResponse();
        readonly IProductRepository _repository;

        public AddProductCommand(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var hasProductWithCode = await _repository.HasProductWithCode(request.Code);

                if (hasProductWithCode)
                {
                    response.Messages.Add(String.Format(MessagesConstant.AlreadyHasProductWithCode, request.Code));
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return response;
                }

                var newProduct = new Product(request.Name, request.Code, request.Price);
                await _repository.AddAsync(newProduct);

                response.StatusCode = System.Net.HttpStatusCode.Created;
                response.Product = new Domain.DTOs.Product.ProductDetailDto
                {
                    Id = newProduct.Id,
                    Code = newProduct.Code,
                    Name = newProduct.Name,
                    Price = newProduct.Price,
                    Active = newProduct.Active,
                    CreationDate = newProduct.CreationDate,
                    UpdateDate = newProduct.UpdateDate
                };
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
