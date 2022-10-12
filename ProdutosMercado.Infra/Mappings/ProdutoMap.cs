using ProdutosMercado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace ProdutosMercado.Infra.Mappings;

[ExcludeFromCodeCoverage]
public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        
        //Chave
        builder.HasKey(x => x.Id);

        //Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome") //opcional se for o mesmo
            .HasColumnType("VARCHAR")
            .HasMaxLength(150);

        //Relacionamentos
        builder
            .HasOne(x => x.Fornecedor)
            .WithMany(x => x.Produtos)
            .HasConstraintName("FK_Produto_Fornecedor");
    }
}