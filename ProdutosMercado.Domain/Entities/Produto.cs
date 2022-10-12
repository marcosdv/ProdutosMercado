namespace ProdutosMercado.Domain.Entities;

public class Produto : Entity
{
    public Produto()
    {
    }

    public Produto(string nome, int fornecedorId)
    {
        Nome = nome;
        FornecedorId = fornecedorId;
    }

    public Produto(int id, string nome, int fornecedorId)
    {
        Id = id;
        Nome = nome;
        FornecedorId = fornecedorId;
    }

    public string Nome { get; set; }
    public int FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }
}