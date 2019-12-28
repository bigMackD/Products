using System;

namespace BackEnd.Products.Shared.DAL.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
