using System.Linq;

namespace BackEnd.Products.Shared.DAL.Repositories.Product
{
    public interface IProductsRepository
    {
        IQueryable<Entities.Products.Product> GetAll();
    }
}
