using EventosAPI.Data.Context;
using EventosAPI.Domain.Core.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EventosAPI.Data.Repositorio
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly EventosContext _eventosContexto;

        #region Construtor
        public RepositorioBase(EventosContext eventosContexto)
        {
            _eventosContexto = eventosContexto;
        }
        #endregion

        #region Adicionar
        public void Adicionar(TEntity obj)
        {
            _eventosContexto.Add(obj);
            _eventosContexto.SaveChanges();
        }
        #endregion

        #region Alterar
        public void Alterar(TEntity obj)
        {
            _eventosContexto.Update(obj);
            _eventosContexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _eventosContexto.SaveChanges();
        }
        #endregion

        #region Deletar
        public void Deletar(TEntity obj)
        {
            _eventosContexto.Remove(obj);
            _eventosContexto.SaveChanges();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _eventosContexto.Dispose();
        }
        #endregion

        #region ObterPorId
        public TEntity ObterPorId(int id)
        {
            return _eventosContexto.Set<TEntity>().Find(id);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<TEntity> ObterTodos()
        {
            return _eventosContexto.Set<TEntity>().AsNoTracking().ToList();
        }
        #endregion
    }
}
