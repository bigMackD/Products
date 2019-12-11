namespace BackEnd.Products.Shared.Infrastructure.Response

{
    public interface IResponse<T>
    {
         bool Success { get; set; }
         string[] Errors { get; set; }
         T Content { get; set; }
    }
}
