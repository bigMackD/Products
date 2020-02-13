using System;
using BackEnd.Products.Contracts.Request.Command.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.Shared.DAL.Entities.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;
using BackEnd.Products.Shared.Infrastructure.CommandHandlers;

namespace BackEnd.Products.Infrastructure.CommandHandlers.Products
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, AddProductResponse>
    {
        private readonly IProductsRepository _productsRepository;

        public AddProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public AddProductResponse Handle(AddProductCommand command)
        {
            if (command == null)
            {
                return new AddProductResponse
                {
                    Success = false,
                    Errors = new[] {"Request is empty!"}
                };
            }

            try
            {
                var product = new Product
                {
                    Name = command.Name,
                    Code = command.Code,
                    Description = command.Description,
                    Price = command.Price,
                    ReleaseDate = command.ReleaseDate,
                    StarRating = command.StarRating,
                    ImageUrl = command.ImageUrl
                };
                _productsRepository.Add(product);
                return new AddProductResponse
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new AddProductResponse
                {
                    Success = false,
                    Errors = new[] {ex.Message}
                };
            }
        }
    }
}