using System;
using BackEnd.Products.Shared.Infrastructure.Command;

namespace BackEnd.Products.Contracts.Request.Command.Products
{
    public class UpdateProductCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
     
    }
}
