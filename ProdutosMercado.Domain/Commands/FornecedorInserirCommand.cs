using ProdutosMercado.Domain.Commands.Interfaces;
using ProdutosMercado.Domain.Validations;

namespace ProdutosMercado.Domain.Commands;

public class FornecedorInserirCommand : Notificavel, ICommand
{
    public FornecedorInserirCommand(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    
    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");
    }
}