using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Validations;

namespace ProdutosMercado.Domain.Commands;

public class FornecedorAlterarCommand : Notificavel, ICommand
{
    public FornecedorAlterarCommand(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");
    }
}