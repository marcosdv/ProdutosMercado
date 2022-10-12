namespace ProdutosMercado.Domain.Entities;

public class Fornecedor : Entity
{
    public Fornecedor(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Produtos = new List<Produto>();
    }

    public Fornecedor(string nome)
    {
        Nome = nome;
        Produtos = new List<Produto>();
    }

    public string Nome { get; private set; }
    public IList<Produto> Produtos { get; set; }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }
}