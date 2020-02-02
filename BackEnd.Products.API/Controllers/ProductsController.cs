using System.Collections.Generic;
using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Contracts.Request.Command.Products;
using BackEnd.Products.Contracts.Request.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.Shared.Infrastructure.CommandHandlers;
using BackEnd.Products.Shared.Infrastructure.QueryHandlers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Products.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IQueryHandler<GetProductListQuery, GetProductListResponse, IEnumerable<ProductModel>> _getProductsQueryHandler;
        private readonly IQueryHandler<GetProductQuery, GetProductResponse, ProductModel> _getProductQueryHandler;
        private readonly ICommandHandler<UpdateProductCommand, UpdateProductResponse> _updateProductCommandHandler;
        private readonly ICommandHandler<DeleteProductCommand, DeleteProductResponse> _deleteProductCommandHandler;

        public ProductsController(
            IQueryHandler<GetProductListQuery, GetProductListResponse, IEnumerable<ProductModel>> getProductsQueryHandler,
            IQueryHandler<GetProductQuery, GetProductResponse, ProductModel> getProductQueryHandler, ICommandHandler<UpdateProductCommand, UpdateProductResponse> updateProductCommandHandler, ICommandHandler<DeleteProductCommand, DeleteProductResponse> deleteProductCommandHandler)
        {
            _getProductsQueryHandler = getProductsQueryHandler;
            _getProductQueryHandler = getProductQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors("AngularOrigin")]
        public IActionResult Get()
        {
            return new JsonResult(_getProductsQueryHandler.Handle(new GetProductListQuery()));
        }
        
        /// <summary>
        /// Returns product by id
        /// </summary>
        /// <param name="query"></param>    
        [HttpPost("get")]
        [EnableCors("AngularOrigin")]
        public IActionResult GetById([FromBody] GetProductQuery query)
        {
             return new JsonResult(_getProductQueryHandler.Handle(query));
        }

        /// <summary>
        /// Edits product with specified id
        /// </summary>
        /// <param name="command"></param>    
        [HttpPatch("edit")]
        [EnableCors("AngularOrigin")]
        public IActionResult Update([FromBody] UpdateProductCommand command)
        {
            return new JsonResult(_updateProductCommandHandler.Handle(command));
        }

        /// <summary>
        /// Deletes product with specified id
        /// </summary>
        /// <param name="command"></param>    
        [HttpDelete("delete")]
        [EnableCors("AngularOrigin")]
        public IActionResult Delete([FromBody] DeleteProductCommand command)
        {
            return  new JsonResult(_deleteProductCommandHandler.Handle(command));
        }
    }
}
