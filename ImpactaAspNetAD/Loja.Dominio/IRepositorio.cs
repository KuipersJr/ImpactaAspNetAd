using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Loja.Dominio
{
    public interface IRepositorio<T> where T : class
    {
        void Adicionar(T entidade);

        T Obter(int id);
        List<T> Obter();
        List<T> Obter(Expression<Func<T, bool>> query);

        void Remover(int id);
    }
}