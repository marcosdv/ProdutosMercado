using ProdutosMercado.Domain.Entities;
using System.Linq.Expressions;

namespace ProdutosMercado.Domain.Queries;

public class FornecedorQueries
{
    public static Expression<Func<Fornecedor, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;
    }
}