using System;
using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Contracts.Request.Command.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.Shared.DAL.Entities.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;
using BackEnd.Products.Shared.Infrastructure.CommandHandlers;

namespace BackEnd.Products.Infrastructure.CommandHandlers.Products
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductResponse, ProductModel>
    {
        private readonly IProductsRepository _productsRepository;

        public UpdateProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public UpdateProductResponse Handle(UpdateProductCommand command)
        {
            if (command == null)
                return new UpdateProductResponse
                {
                    Success = false,
                    Errors = new[] { "Request is empty!" }
                };
            try
            {
                var product = new Product
                {
                    Id = command.Id,
                    Name = command.Name,
                    Code = command.Code,
                    ReleaseDate = command.ReleaseDate,
                    Price = command.Price
                };
                var updatedProduct = _productsRepository.Update(product);
                var productResponse = new ProductModel
                {
                    Id = updatedProduct.Id,
                    Description = updatedProduct.Description,
                    Code = updatedProduct.Code,
                    ImageUrl = updatedProduct.ImageUrl,
                    Name = updatedProduct.Name,
                    Price = updatedProduct.Price,
                    ReleaseDate = updatedProduct.ReleaseDate,
                    StarRating = updatedProduct.StarRating
                };

                return new UpdateProductResponse
                {
                    Success = true,
                    Content = productResponse
                };
            }
            catch (Exception ex)
            {
                return new UpdateProductResponse()
                {
                    Success = false,
                    Errors = new[] {ex.Message}
                };
            }
        }
    }
}
