using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Contracts.Request.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;
using BackEnd.Products.Shared.Infrastructure.QueryHandlers;

namespace BackEnd.Products.Infrastructure.QueryHandlers.Products
{
    public class GetProductListQueryHandler : IQueryHandler<GetProductListQuery, GetProductListResponse, IEnumerable<ProductModel>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductListQueryHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public GetProductListResponse Handle(GetProductListQuery query)
        {
            if (query == null)
                return new GetProductListResponse
                {
                    Success = false,
                    Errors = new[] { "Request is empty!" }
                };
            try
            {
                var products = _productsRepository.GetAll();
                var productsMapped = products.Select(x => new ProductModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    ReleaseDate = x.ReleaseDate,
                    Description = x.Description,
                    Price = x.Price,
                    StarRating = x.StarRating,
                    ImageUrl = x.ImageUrl
                });
                return new GetProductListResponse
                {
                    Success = true,
                    Content = productsMapped,
                };
            }
            catch (Exception ex)
            {
                return new GetProductListResponse
                {
                    Success = false,
                    Errors = new[] { ex.Message }
                };
            }
        }
    }
}
