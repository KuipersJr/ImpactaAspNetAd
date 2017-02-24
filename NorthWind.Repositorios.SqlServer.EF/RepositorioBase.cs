using NorthWind.Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NorthWind.Repositorios.SqlServer.EF
{
    public class RepositorioBase<T> : IRepositorio<T> where T : class
    {
        public void Inserir(T entidade)
        {
            using (var contexto = new LojaDbContext())
            {
                contexto.Set<T>().Add(entidade);
                contexto.SaveChanges();
            }
        }

        public void Atualizar(T entidade)
        {
            using (var contexto = new LojaDbContext())
            {
                contexto.Set<T>().Attach(entidade);
                contexto.Entry(entidade).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public List<T> Selecionar()
        {
            using (var contexto = new LojaDbContext())
            {
                return contexto.Set<T>().ToList();
            }
        }

        public T Selecionar(int id)
        {
            using (var contexto = new LojaDbContext())
            {
                return contexto.Set<T>().Find(id);
            }
        }

        public void Excluir(int id)
        {
            using (var contexto = new LojaDbContext())
            {
                var entidade = contexto.Set<T>().Find(id);

                contexto.Set<T>().Remove(entidade);
                contexto.SaveChanges();
            }
        }
    }
}