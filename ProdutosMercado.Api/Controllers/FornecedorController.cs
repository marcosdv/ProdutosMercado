using Microsoft.AspNetCore.Mvc;
using ProdutosMercado.Domain.Commands;
using ProdutosMercado.Domain.Entities;
using ProdutosMercado.Domain.Handlers;
using ProdutosMercado.Domain.Repositories;

namespace ProdutosMercado.Api.Controllers;

[ApiController]
[Route("v1/fornecedor")]
public class FornecedorController : ControllerBase
{
    private readonly IFornecedorRepository _repository;
    private readonly FornecedorHandler _handler;

    public FornecedorController(IFornecedorRepository repository, FornecedorHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }

    [HttpGet]
    public IEnumerable<Fornecedor> BuscarTodos() => _repository.BuscarTodos();

    [HttpGet("id")]
    public Fornecedor? BuscarPorId(int id) => _repository.BuscarPorId(id);

    [HttpPost]
    public CommandResult Inserir(FornecedorInserirCommand command) => (CommandResult)_handler.Handle(command);

    [HttpPut]
    public CommandResult Alterar(FornecedorAlterarCommand command) => (CommandResult)_handler.Handle(command);

    [HttpDelete]
    public CommandResult Excluir(FornecedorExcluirCommand command) => (CommandResult)_handler.Handle(command);
}