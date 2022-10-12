using ProdutosMercado.Domain.Entities;
using ProdutosMercado.Domain.Queries;
using ProdutosMercado.Domain.Repositories;
using ProdutosMercado.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ProdutosMercado.Infra.Repositories;

[ExcludeFromCodeCoverage]
public class ProdutoRepository : IProdutoRepository
{
    private readonly DataContext _context;

    public ProdutoRepository(DataContext context)
    {
        _context = context;
    }

    public void Inserir(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public void Alterar(Produto produto)
    {
        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Produto produto)
    {
        _context.Remove(produto);
        _context.SaveChanges();
    }

    public IEnumerable<Produto> BuscarTodos()
    {
        return _context.Produtos
            .AsNoTracking()
            .Include(x => x.Fornecedor)
            .OrderBy(x => x.Nome);
    }

    public Produto? BuscarPorId(int id)
    {
        return _context.Produtos
            .AsNoTracking()
            .Where(ProdutoQueries.BuscarPorId(id))
            .FirstOrDefault();
    }
}