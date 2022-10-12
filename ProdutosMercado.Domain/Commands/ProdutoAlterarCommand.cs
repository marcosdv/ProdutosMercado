using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Validations;

namespace ProdutosMercado.Domain.Commands;

public class ProdutoAlterarCommand : Notificavel, ICommand
{
    public ProdutoAlterarCommand(int id, string nome, int idFornecedor)
    {
        Id = id;
        Nome = nome;
        IdFornecedor = idFornecedor;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int IdFornecedor { get; set; }
    
    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (IdFornecedor <= 0)
            AdicionarNotificacao("Editora informada inválida");
    }
}