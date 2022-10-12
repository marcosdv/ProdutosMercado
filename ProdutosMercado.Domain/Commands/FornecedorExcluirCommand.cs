using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Validations;

namespace ProdutosMercado.Domain.Commands;

public class FornecedorExcluirCommand : Notificavel, ICommand
{
    public FornecedorExcluirCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");
    }
}