using APICatalogo.Models;
using APICatalogo.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutosPorPreco();
        PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters);
    }
}
