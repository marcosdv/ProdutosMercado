using ProdutosMercado.Domain.Entities;
using ProdutosMercado.Domain.Queries;
using ProdutosMercado.Domain.Repositories;
using ProdutosMercado.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ProdutosMercado.Infra.Repositories;

[ExcludeFromCodeCoverage]
public class FornecedorRepository : IFornecedorRepository
{
    private readonly DataContext _context;

    public FornecedorRepository(DataContext context)
    {
        _context = context;
    }

    public void Inserir(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        _context.SaveChanges();
    }

    public void Alterar(Fornecedor fornecedor)
    {
        _context.Entry(fornecedor).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Fornecedor fornecedor)
    {
        _context.Remove(fornecedor);
        _context.SaveChanges();
    }

    public IEnumerable<Fornecedor> BuscarTodos()
    {
        return _context.Fornecedores
            .AsNoTracking()
            .Include(x => x.Produtos)
            .OrderBy(x => x.Nome);
    }

    public Fornecedor? BuscarPorId(int id)
    {
        return _context.Fornecedores
            .AsNoTracking()
            .Where(FornecedorQueries.BuscarPorId(id))
            .FirstOrDefault();
    }
}
