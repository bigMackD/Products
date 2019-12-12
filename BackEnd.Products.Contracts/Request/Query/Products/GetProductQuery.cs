using BackEnd.Products.Shared.Infrastructure.Command;
using BackEnd.Products.Shared.Infrastructure.Query;
using BackEnd.Products.Shared.Infrastructure.QueryHandlers;

namespace BackEnd.Products.Contracts.Request.Products
{
    public class GetProductQuery : IQuery
    {
        public int Id { get; set; }
    }
}
