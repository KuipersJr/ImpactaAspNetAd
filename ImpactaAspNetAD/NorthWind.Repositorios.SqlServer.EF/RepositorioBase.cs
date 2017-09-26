using Loja.Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace Loja.Repositorios.SqlServer.EF
{
    public class RepositorioBase<T> : IRepositorio<T> where T : class
    {
        private LojaDbContext _contexto;

        public RepositorioBase(LojaDbContext _contexto)
        {
            this._contexto = _contexto;
        }

        public void Adicionar(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
        }

        public List<T> Obter()
        {
            return _contexto.Set<T>().ToList();
        }

        public List<T> Obter(Expression<Func<T, bool>> query)
        {
            return _contexto.Set<T>().Where(query).ToList();
        }

        public T Obter(int id)
        {
            return _contexto.Set<T>().Find(id);
        }

        public void Remover(int id)
        {
            var entidade = _contexto.Set<T>().Find(id);

            _contexto.Set<T>().Remove(entidade);
        }
    }
}