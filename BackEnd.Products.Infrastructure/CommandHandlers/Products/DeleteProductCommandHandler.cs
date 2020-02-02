using System;
using BackEnd.Products.Contracts.Request.Command.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;
using BackEnd.Products.Shared.Infrastructure.CommandHandlers;

namespace BackEnd.Products.Infrastructure.CommandHandlers.Products
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IProductsRepository _productsRepository;

        public DeleteProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public DeleteProductResponse Handle(DeleteProductCommand command)
        {
            if (command == null)
            {
                return new DeleteProductResponse
                {
                    Success = false,
                    Errors = new[] {"Request is empty!"}
                };
            }

            try
            {
                _productsRepository.Delete(command.Id);
                return new DeleteProductResponse
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new DeleteProductResponse
                {
                    Success = false,
                    Errors = new[] {ex.Message}
                };
            }
        }
    }
}
