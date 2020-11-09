using System.Collections.Generic;

namespace EventosAPI.Domain.Core.Interfaces.Servicos
{
    public interface IAPIServicoBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        void Adicionar(TEntity obj);
        void Alterar(TEntity obj);
        void Deletar(TEntity obj);
        void Dispose();
    }
}
