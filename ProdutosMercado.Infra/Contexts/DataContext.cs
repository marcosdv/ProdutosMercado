using ProdutosMercado.Domain.Entities;
using ProdutosMercado.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ProdutosMercado.Infra.Contexts;

[ExcludeFromCodeCoverage]
public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FornecedorMap());
        modelBuilder.ApplyConfiguration(new ProdutoMap());
    }
}