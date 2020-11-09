using System.Collections.Generic;

namespace EventosAPI.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        void Adicionar(TEntity obj);
        void Alterar(TEntity obj);
        void Deletar(TEntity obj);
        void Dispose();
    }
}
