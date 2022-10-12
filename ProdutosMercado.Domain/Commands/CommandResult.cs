using ProdutosMercado.Domain.Commands.Interfaces;

namespace ProdutosMercado.Domain.Commands;

public class CommandResult : ICommandResult
{
    public CommandResult(bool successo, string menssagem, object dados)
    {
        Successo = successo;
        Menssagem = menssagem;
        Dados = dados;
    }

    public bool Successo { get; set; }
    public string Menssagem { get; set; }
    public object Dados { get; set; }
}