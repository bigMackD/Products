﻿using BackEnd.Products.Shared.Infrastructure.Response;

namespace BackEnd.Products.Contracts.Response.Products
{
    public class DeleteProductResponse : IBaseResponse
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
    }
}
