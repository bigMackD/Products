using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Products.Contracts.Request.Products;
using BackEnd.Products.Infrastructure.QueryHandlers.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetProductListQueryHandler _productsQueryHandler;

        public ProductsController(GetProductListQueryHandler productsQueryHandler)
        {
            _productsQueryHandler = productsQueryHandler;
        }
        public IActionResult Get(GetProductListRequest request)
        {
            return new JsonResult(_productsQueryHandler.Handle(request));
        }
    }
}