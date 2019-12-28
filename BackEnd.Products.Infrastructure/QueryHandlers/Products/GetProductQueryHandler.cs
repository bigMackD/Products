using System;
using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Contracts.Request.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;
using BackEnd.Products.Shared.Infrastructure.QueryHandlers;

namespace BackEnd.Products.Infrastructure.QueryHandlers.Products
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductResponse, ProductModel>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductQueryHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public GetProductResponse Handle(GetProductQuery query)
        {
            if(query == null)
                return new GetProductResponse
                {
                    Success = false,
                    Errors = new[] { "Request is empty!" }
                };
            try
            {
                var product = _productsRepository.Get(query.Id);
                var model = new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    ReleaseDate = product.ReleaseDate,
                    Description = product.Description,
                    Price = product.Price,
                    StarRating = product.StarRating,
                    ImageUrl = product.ImageUrl
                };

                return new GetProductResponse
                {
                    Success = true,
                    Content = model
                };
            }
            catch (Exception ex)
            {
                return new GetProductResponse
                {
                    Success = false,
                    Errors = new[] { ex.Message }
                };
            }
        }
    }
}
