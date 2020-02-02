using System.Linq;

namespace BackEnd.Products.Shared.DAL.Repositories.Product
{
    public interface IProductsRepository
    {
        IQueryable<Entities.Products.Product> GetAll();
        Entities.Products.Product Get(int id);
        Entities.Products.Product Update(Entities.Products.Product product);
        void Delete(int id);
    }
}
