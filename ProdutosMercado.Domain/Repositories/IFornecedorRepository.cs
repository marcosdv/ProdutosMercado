using ProdutosMercado.Domain.Entities;

namespace ProdutosMercado.Domain.Repositories;

public interface IFornecedorRepository
{
    void Inserir(Fornecedor editora);
    void Alterar(Fornecedor editora);
    void Excluir(Fornecedor editora);
    IEnumerable<Fornecedor> BuscarTodos();
    Fornecedor? BuscarPorId(int id);
}