using System;
using BackEnd.Products.Shared.Infrastructure.Command;

namespace BackEnd.Products.Contracts.Request.Command.Products
{
    public class AddProductCommand : ICommand
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}