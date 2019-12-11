using BackEnd.Products.Shared.Infrastructure.Query;
using BackEnd.Products.Shared.Infrastructure.Response;

namespace BackEnd.Products.Shared.Infrastructure.QueryHandlers
{
    public interface IQueryHandler<in TQuery, out TResponse, T>
        where TQuery : IQuery
        where TResponse : IResponse<T>
    {
        TResponse Handle(TQuery query);

    }
}
