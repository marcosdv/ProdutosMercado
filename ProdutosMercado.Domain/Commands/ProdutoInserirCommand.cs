using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Validations;

namespace ProdutosMercado.Domain.Commands;

public class ProdutoInserirCommand : Notificavel, ICommand
{
    public ProdutoInserirCommand(string nome, int idFornecedor)
    {
        Nome = nome;
        IdFornecedor = idFornecedor;
    }

    public string Nome { get; set; }
    public int IdFornecedor { get; set; }
    
    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (IdFornecedor <= 0)
            AdicionarNotificacao("Editora informada inválida");
    }
}