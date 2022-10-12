using ProdutosMercado.Domain.Entities;

namespace ProdutosMercado.Domain.Repositories;

public interface IProdutoRepository
{
    void Inserir(Produto livro);
    void Alterar(Produto livro);
    void Excluir(Produto livro);
    IEnumerable<Produto> BuscarTodos();
    Produto? BuscarPorId(int id);
}