using ProdutosMercado.Domain.Entities;
using System.Linq.Expressions;

namespace ProdutosMercado.Domain.Queries;

public class ProdutoQueries
{
    public static Expression<Func<Produto, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;
    }
}
