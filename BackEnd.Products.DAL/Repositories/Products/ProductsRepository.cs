using System.Collections.Generic;
using System.Linq;
using BackEnd.Products.Shared.DAL.Entities.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;

namespace BackEnd.Products.DAL.Repositories.Products
{
    public class ProductsRepository : IProductsRepository
    {
        public IQueryable<Product> GetAll()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Computer",
                    Price = 2200
                },
                new Product()
                {
                    Id = 2,
                    Name = "Display",
                    Price = 1900
                },
                new Product()
                {
                    Id = 3,
                    Name = "Phone",
                    Price = 900
                },
                new Product()
                {
                    Id = 4,
                    Name = "Speaker",
                    Price = 70
                }
            };
            return products.AsQueryable();
        }
    }
}
