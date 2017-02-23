using NorthWind.Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class RepositorioBase<T> : IRepositorio<T> where T : class
    {
        private LojaDbContext _contexto = new LojaDbContext();

        public void Inserir(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            _contexto.Set<T>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public List<T> Selecionar()
        {
            return _contexto.Set<T>().ToList();
        }

        public T Selecionar(int id)
        {
            return _contexto.Set<T>().Find(id);
        }

        public void Excluir(int id)
        {
            var entidade = Selecionar(id);

            _contexto.Set<T>().Remove(entidade);
            _contexto.SaveChanges();
        }
    }
}