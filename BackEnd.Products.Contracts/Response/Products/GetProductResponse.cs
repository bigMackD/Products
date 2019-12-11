using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Shared.Infrastructure.Response;

namespace BackEnd.Products.Contracts.Response.Products
{
    public class GetProductResponse : IResponse<ProductModel>
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public ProductModel Content { get; set; }
    }
}
