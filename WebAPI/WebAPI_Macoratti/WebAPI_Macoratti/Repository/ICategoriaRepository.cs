using APICatalogo.Models;
using APICatalogo.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
        PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters);
    }
}
