namespace BackEnd.Products.Shared.Infrastructure.Response

{
    public interface IResponse<T> : IBaseResponse
    {
        T Content { get; set; }
    }
}
