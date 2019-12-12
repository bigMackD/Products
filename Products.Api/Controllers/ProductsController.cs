using System.Collections.Generic;
using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Contracts.Request.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.Shared.Infrastructure.QueryHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Products.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IQueryHandler<GetProductListQuery, GetProductListResponse, IEnumerable<ProductModel>> _productsQueryHandler;
        private readonly IQueryHandler<GetProductQuery, GetProductResponse, ProductModel> _productQueryHandler;

        public ProductsController(
            IQueryHandler<GetProductListQuery, GetProductListResponse, IEnumerable<ProductModel>> productsQueryHandler,
            IQueryHandler<GetProductQuery, GetProductResponse, ProductModel> productQueryHandler
            )
        {
            _productsQueryHandler = productsQueryHandler;
            _productQueryHandler = productQueryHandler;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        [HttpGet("get")]
        public IActionResult Get()
        {
            return new JsonResult(_productsQueryHandler.Handle(new GetProductListQuery()));
        }

        /// <summary>
        /// Returns product by id
        /// </summary>
        /// <param name="query"></param>    
        [HttpPost("get")]
        public IActionResult GetById([FromBody] GetProductQuery query)
        {
            return new JsonResult(_productQueryHandler.Handle(query));
        }
    }
}
