using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Shared.Infrastructure.Response;

namespace BackEnd.Products.Contracts.Response.Products
{
    public class GetProductListResponse : IResponse<IEnumerable<ProductModel>>
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public IEnumerable<ProductModel> Content { get; set; }
    }
}
