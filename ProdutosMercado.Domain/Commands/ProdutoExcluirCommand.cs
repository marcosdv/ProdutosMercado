using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Validations;

namespace ProdutosMercado.Domain.Commands;

public class ProdutoExcluirCommand : Notificavel, ICommand
{
    public ProdutoExcluirCommand(int id, int idFornecedor)
    {
        Id = id;
        IdFornecedor = idFornecedor;
    }

    public int Id { get; set; }
    public int IdFornecedor { get; set; }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (IdFornecedor <= 0)
            AdicionarNotificacao("Editora informada inválida");
    }
}