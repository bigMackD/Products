using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Products.Shared.DAL.Entities.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;

namespace BackEnd.Products.DAL.Repositories.Products
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Leaf Rake",
                Code = "GDN-0011",
                ReleaseDate = new DateTime(2019,3,19),
                Description = "Leaf rake with 48-inch wooden handle.",
                Price =  19.95M,
                StarRating = 3.2M
            },
            new Product
            {
                Id = 2,
                Name = "Garden Cart",
                Code = "GDN-0023",
                ReleaseDate = new DateTime(2019,4,12),
                Description = "15 gallon capacity rolling garden cart",
                Price =  39.95M,
                StarRating = 4.2M
            },
            new Product
            {
                Id = 3,
                Name = "Hammer",
                Code = "TBX-0048",
                ReleaseDate = new DateTime(2017,8,21),
                Description = "Curved claw steel hammer",
                Price =  9.5M,
                StarRating = 2.2M
            },
            new Product
            {
                Id = 4,
                Name = "Saw",
                Code = "TBX-0022",
                ReleaseDate = new DateTime(2016,1,12),
                Description = "15-inch steel blade hand saw.",
                Price =  11.55M,
                StarRating = 3.7M
            },
        };
        public IQueryable<Product> GetAll()
        {
            return _products.AsQueryable();
        }

        public Product Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public Product Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index == -1)
                throw new NullReferenceException("Product with specified id was not found and cannot be updated!");

            _products[index].Name = product.Name;
            _products[index].Code = product.Code;
            _products[index].ReleaseDate = product.ReleaseDate;
            _products[index].Price = product.Price;
            return _products[index];
        }

        public void Delete(int id)
        {
            _products.RemoveAll(x => x.Id == id);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }
    }
}
