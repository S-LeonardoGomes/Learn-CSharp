using EventosAPI.Domain.Core.Interfaces.Repositorios;
using EventosAPI.Domain.Core.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace EventosAPI.Servico.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IAPIServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorioBase;

        #region Construtor
        public ServicoBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }
        #endregion

        #region Adicionar
        public void Adicionar(TEntity obj)
        {
            _repositorioBase.Adicionar(obj);
        }
        #endregion

        #region Alterar
        public void Alterar(TEntity obj)
        {
            _repositorioBase.Alterar(obj);
        }
        #endregion

        #region Deletar
        public void Deletar(TEntity obj)
        {
            _repositorioBase.Deletar(obj);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _repositorioBase.Dispose();
        }
        #endregion

        #region ObterPorId
        public TEntity ObterPorId(int id)
        {
            return _repositorioBase.ObterPorId(id);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorioBase.ObterTodos();
        }
        #endregion
    }
}
