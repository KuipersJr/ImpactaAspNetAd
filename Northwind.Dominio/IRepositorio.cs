using System.Collections.Generic;

namespace NorthWind.Dominio
{
    public interface IRepositorio<T> where T : class
    {
        void Inserir(T entidade);
        void Atualizar(T entidade);
        List<T> Selecionar();
        T Selecionar(int id);
        void Excluir(int id);
    }
}