using Microsoft.AspNetCore.Mvc;
using ProdutosMercado.Domain.Commands;
using ProdutosMercado.Domain.Entities;
using ProdutosMercado.Domain.Handlers;
using ProdutosMercado.Domain.Repositories;

namespace ProdutosMercado.Api.Controllers;

[ApiController]
[Route("v1/produto")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _repository;
    private readonly ProdutoHandler _handler;

    public ProdutoController(IProdutoRepository repository, ProdutoHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }

    [HttpGet]
    public IEnumerable<Produto> BuscarTodos() => _repository.BuscarTodos();

    [HttpGet("{id}")]
    public Produto? BuscarPorId(int id) => _repository.BuscarPorId(id);

    [HttpPost]
    public CommandResult Inserir(ProdutoInserirCommand command) => (CommandResult)_handler.Handle(command);

    [HttpPut]
    public CommandResult Alterar(ProdutoAlterarCommand command) => (CommandResult)_handler.Handle(command);

    [HttpDelete]
    public CommandResult Excluir(ProdutoExcluirCommand command) => (CommandResult)_handler.Handle(command);
}