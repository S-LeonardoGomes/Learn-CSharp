﻿using DIO_CursoAPI.Business.Entities;
using DIO_CursoAPI.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIO_CursoAPI.Infraestruture.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _contexto;

        public CursoRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Curso curso)
        {
            _contexto.Curso.Add(curso);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Curso> ObterPorUsuario(int codigoUsuario)
        {
            return _contexto.Curso.Where(w => w.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}
