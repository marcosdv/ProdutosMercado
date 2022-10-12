using ProdutosMercado.Domain.Commands;
using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Entities;
using ProdutosMercado.Domain.Handlers.Interfaces;
using ProdutosMercado.Domain.Repositories;

namespace ProdutosMercado.Domain.Handlers;

public class ProdutoHandler :
    IHandler<ProdutoInserirCommand>,
    IHandler<ProdutoAlterarCommand>,
    IHandler<ProdutoExcluirCommand>
{
    private readonly IProdutoRepository _repository;

    public ProdutoHandler(IProdutoRepository repository) => _repository = repository;

    public ICommandResult Handle(ProdutoInserirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Dados do produto incorretos", command.Notificacoes);

        var produto = new Produto(command.Nome, command.IdFornecedor);

        _repository.Inserir(produto);

        return new CommandResult(true, "Produto inserido", produto);
    }

    public ICommandResult Handle(ProdutoAlterarCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Dados do produto incorretos", command.Notificacoes);

        var produto = _repository.BuscarPorId(command.Id);

        if (produto == null)
            return new CommandResult(false, "Produto não encontrado", command.Notificacoes);

        produto.AlterarNome(command.Nome);

        _repository.Alterar(produto);

        return new CommandResult(true, "Produto inserido", produto);
    }

    public ICommandResult Handle(ProdutoExcluirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Dados do produto incorretos", command.Notificacoes);

        var produto = _repository.BuscarPorId(command.Id);

        if (produto == null)
            return new CommandResult(false, "Produto não encontrado", command.Notificacoes);

        _repository.Excluir(produto);

        return new CommandResult(true, "Produto excluido", produto);
    }
}