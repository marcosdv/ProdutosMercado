using ProdutosMercado.Domain.Commands;
using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Entities;
using ProdutosMercado.Domain.Handlers.Interfaces;
using ProdutosMercado.Domain.Repositories;

namespace ProdutosMercado.Domain.Handlers;

public class FornecedorHandler :
    IHandler<FornecedorInserirCommand>,
    IHandler<FornecedorAlterarCommand>,
    IHandler<FornecedorExcluirCommand>
{
    private readonly IFornecedorRepository _repository;

    public FornecedorHandler(IFornecedorRepository repository) => _repository = repository;

    public ICommandResult Handle(FornecedorInserirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Dados do fornecedor incorretos", command.Notificacoes);

        var fornecedor = new Fornecedor(command.Nome);

        _repository.Inserir(fornecedor);

        return new CommandResult(true, "Fornecedor inserido", fornecedor);
    }

    public ICommandResult Handle(FornecedorAlterarCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Dados do fornecedor incorretos", command.Notificacoes);

        var fornecedor = _repository.BuscarPorId(command.Id);

        if (fornecedor == null)
            return new CommandResult(false, "Fornecedor não encontrado", command.Notificacoes);

        fornecedor.AlterarNome(command.Nome);

        _repository.Alterar(fornecedor);

        return new CommandResult(true, "Fornecedor alterado", fornecedor);
    }

    public ICommandResult Handle(FornecedorExcluirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Dados do fornecedor incorretos", command.Notificacoes);

        var fornecedor = _repository.BuscarPorId(command.Id);

        if (fornecedor == null)
            return new CommandResult(false, "Fornecedor não encontrado", command.Notificacoes);

        _repository.Excluir(fornecedor);

        return new CommandResult(true, "Fornecedor excluído", fornecedor);
    }
}