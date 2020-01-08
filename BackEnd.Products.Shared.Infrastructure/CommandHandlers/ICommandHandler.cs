using BackEnd.Products.Shared.Infrastructure.Command;
using BackEnd.Products.Shared.Infrastructure.Response;

namespace BackEnd.Products.Shared.Infrastructure.CommandHandlers
{
    public interface ICommandHandler<TCommand, TResponse, T>
    where TCommand : ICommand
    where TResponse : IResponse<T>
    {
        TResponse Handle(TCommand command);
    }
}
