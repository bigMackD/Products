using BackEnd.Products.Shared.Infrastructure.Command;

namespace BackEnd.Products.Contracts.Request.Command.Products
{
    public class DeleteProductCommand : ICommand
    {
        public int Id { get; set; }
    }
}
