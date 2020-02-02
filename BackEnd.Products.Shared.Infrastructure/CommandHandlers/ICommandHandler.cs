using BackEnd.Products.Shared.Infrastructure.Command;
using BackEnd.Products.Shared.Infrastructure.Response;

namespace BackEnd.Products.Shared.Infrastructure.CommandHandlers
{
    public interface ICommandHandler<in TCommand, out TResponse>
    where TCommand : ICommand
    where TResponse : IBaseResponse
    {
        TResponse Handle(TCommand command);
    }
}
