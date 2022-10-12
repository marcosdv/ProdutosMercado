using ProdutosMercado.Domain.Commands.Interfaces;

namespace ProdutosMercado.Domain.Handlers.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}